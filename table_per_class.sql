DROP TABLE IF EXISTS labels;
DROP TABLE IF EXISTS button;
DROP TABLE IF EXISTS textbox;
DROP TABLE IF EXISTS controlbase;
DROP TABLE IF EXISTS columncontainer;
DROP TABLE IF EXISTS containerbase_children;
DROP TABLE IF EXISTS containerbase;
DROP TABLE IF EXISTS pages;
DROP TABLE IF EXISTS elements;



CREATE TABLE elements (
    id INT IDENTITY(1,1) PRIMARY KEY,
    element_type varchar(32) NOT NULL,
    width INT NOT NULL DEFAULT '0',
    height INT NOT NULL DEFAULT '0'
);

CREATE TABLE pages (
	page_id INT NOT NULL PRIMARY KEY,
    title varchar(32) NOT NULL,
    classname varchar(32) NOT NULL, --bruges ikke
    main_element_id INT NOT NULL,
--    main_element_type VARCHAR(32) NOT NULL DEFAULT (SELECT element_type FROM elements WHERE id = main_element_id),
    CONSTRAINT fk_pages_element_id FOREIGN KEY(page_id) REFERENCES elements(id),
    CONSTRAINT fk_pages_main_element_id FOREIGN KEY(main_element_id) REFERENCES elements(id)
);

--CREATE TRIGGER
   
CREATE TABLE containerbase(
	container_id INT NOT NULL PRIMARY KEY,
	CONSTRAINT fk_containerbase_element_id FOREIGN KEY(container_id) REFERENCES elements(id)
);

CREATE TABLE containerbase_children(
	parent_id INT NOT NULL,
	child_id INT NOT NULL, 
	CONSTRAINT fk_containerbase_container_id FOREIGN KEY (parent_id) REFERENCES containerbase(container_id),
	CONSTRAINT fk_containerbase_child_id FOREIGN KEY (child_id) REFERENCES elements(id),
	PRIMARY KEY(parent_id, child_id)
);

CREATE TABLE columncontainer (
	columncontainer_id INT NOT NULL PRIMARY KEY,
	CONSTRAINT fk_columncontainer_element_id FOREIGN KEY(columncontainer_id) REFERENCES containerbase(container_id)
);
	
CREATE TABLE labels (
	label_id int PRIMARY KEY,
	content TEXT,
	CONSTRAINT fk_label_element_id FOREIGN KEY (label_id) REFERENCES elements(id)
);
CREATE TABLE controlbase (
	control_id INT PRIMARY KEY,
	CONSTRAINT fk_controlbase_element_id FOREIGN KEY(control_id) REFERENCES elements(id)
);

CREATE TABLE button ( 
	button_id INT PRIMARY KEY NOT NULL,
	content TEXT DEFAULT ''
	CONSTRAINT fk_button_element_id FOREIGN KEY (button_id) REFERENCES controlbase(control_id)
);
CREATE TABLE textbox ( 
	textbox_id INT PRIMARY KEY NOT NULL,
	content TEXT DEFAULT ''
	CONSTRAINT fk_textbox_element_id FOREIGN KEY (textbox_id) REFERENCES controlbase(control_id)
);
GO;

DECLARE @childId int

--Create column container
INSERT INTO elements
	(element_type) VALUES ('ColumnContainer')
DECLARE @elementId int
SET @elementId = SCOPE_IDENTITY()
INSERT INTO containerbase( container_id ) VALUES (@elementId)
INSERT INTO columncontainer
	(columncontainer_id) VALUES (@elementId)

--Create label in column container
INSERT INTO elements
 	(element_type) VALUES ('Label')
SET @childId = SCOPE_IDENTITY()
INSERT INTO labels (label_id, content) VALUES (@childId, 'Username')

INSERT INTO containerbase_children (parent_id, child_id) VALUES (@elementId, @childId)

--Create textbox in container
INSERT INTO elements (element_type) VALUES ('TextBox')
SET @childId = SCOPE_IDENTITY()

INSERT INTO controlbase (control_id) VALUES (@childId)
INSERT INTO textbox (textbox_id, content) VALUES (@childId,'Hoxer')
INSERT INTO containerbase_children (parent_id, child_id) VALUES (@elementId, @childId)

--Create page
INSERT INTO elements
	(element_type) VALUES ('Page')
SET @elementId = SCOPE_IDENTITY()
INSERT INTO pages( page_id, title, classname, main_element_id ) VALUES (@elementId, 'Login', 'LoginPage', 1)


--View table-per-hierarchy
SELECT id, width, height, element_type, labels.content, textbox.content, button.content
	FROM elements e 
		LEFT JOIN labels
			ON labels.label_id = e.id
		LEFT JOIN containerbase
			ON containerbase.container_id = e.id 
		LEFT JOIN columncontainer 
			ON columncontainer.columncontainer_id = containerbase.container_id
		LEFT JOIN controlbase 
			ON controlbase.control_id = e.id
		LEFT JOIN textbox
			ON textbox.textbox_id = controlbase.control_id
		LEFT JOIN button
			ON button.button_id = controlbase.control_id
		LEFT JOIN pages
			ON pages.page_id = e.id


	
