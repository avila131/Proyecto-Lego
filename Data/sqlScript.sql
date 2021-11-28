create database trial;

-- Primero hay que cargar los valores 
use trial;

create table parts(
	part_num varchar(20) PRIMARY KEY,
    name varchar(250),
    part_cat_id int
);

load data local infile 'C:/Users/josel/Pictures/Lego/parts.csv'
into table parts
fields terminated by ','
lines terminated by '\n'
ignore 1 rows;



create table inventory_parts(
	inventory_id int ,
    part_num varchar(20),
    color_id int,
    quantity int,
    is_spare bool
);

load data local infile 'C:/Users/josel/Pictures/Lego/inventory_parts.csv'
into table inventory_parts
fields terminated by ','
lines terminated by '\n'
ignore 1 rows;

create table inventories (
	id int,
    version int,
    set_num varchar(20)
);

load data local infile 'C:/Users/josel/Pictures/Lego/inventories.csv'
into table inventories
fields terminated by ','
lines terminated by '\n'
ignore 1 rows;


create table inventory_sets(
	inventory_id int,
    set_num varchar(20),
    quantity int
);

drop table inventory_sets;


load data local infile 'C:/Users/josel/Pictures/Lego/inventory_sets.csv'
into table inventory_sets
fields terminated by ','
lines terminated by '\n'
ignore 1 rows;


create table sets(
	set_num varchar(20),
    name varchar(256),
    year int,
    theme_id int,
    num_parts int
);

drop table sets;

load data local infile 'C:/Users/josel/Pictures/Lego/sets.csv'
into table sets
fields terminated by ','
lines terminated by '\n'
ignore 1 rows;



-- Realizar natural joins

-- Get parts in a set
SELECT set_num AS 'Number of set', sets.name AS 'Name of Set',
part_num AS 'Part number', parts.name AS 'Part Name', quantity AS 'Quantity'
FROM
sets NATURAL JOIN inventories JOIN inventory_parts NATURAL JOIN parts
on (inventories.id=inventory_parts.inventory_id)
where sets.name = "Darth Maul";

select * from sets WHERE sets.name = "Darth Maul";





