-- SQL
-- Structured Query Language
-- In SQL, we use tables and rows to organize our data
-- SQL is considered a declarative language, which means we tell them what we want
-- instead of how to exactly do something

-- Declarative vs Imperative

-- To create a table, use Create keyword
-- Create Table TABLE_NAME
-- configure our columns here
-- );
-- CREATE keyword is part of Data Definition Language (DDL) which contains keywords to define your data
-- Use DROP keyword to complete remove the resource (table, etc)
-- Drop Table ReimbursementTickets;
Truncate Table ReimbursementTickets;
-- Primary Key is a set of one or more columns we use to uniquely idenify a row in a table
-- They can't be duplicates nor they can be left empty
Create Table ReimbursementTickets (
    -- Id int PRIMARYKEY IDENTITY(1, 1),
    UserName nvarchar(20),
    TicketTitle nvarchar(40),
    TicketDescription nvarchar(200),
    TicketStatus nvarchar(20)
);

-- To add a row to table, use INSERT keyword
INSERT INTO ReimbursementTickets(UserName, TicketTitle, TicketDescription, TicketStatus) VALUES ('darth', 'repairs', 'death star blew up', 'pending');

-- To retrieve the data use SELECT keyword
SELECT UserName, TicketTitle, TicketDescription, TicketStatus FROM ReimbursementTickets;

-- Get all the columns from the following table
SELECT * FROM ReimbursementTickets;

-- use Delete keyword to get rid of 1 or more specific rows
DELETE FROM ReimbursementTickets WHERE UserName = 'darth';

-- INSERT / Delete is part of Data Manipulation Language (DML) which modifies one or more rows

-- Sub languages in SQL (DDL, DML, DQL, TCL, etc.) are a way to categorize different keywords according to their functionality
-- Data Definition Language : deals with the structure of the data
--      CREATE, ALTER, DROP, TRUNCATE
-- Data Manipulation Language : Modifies the rows in the table
--      INSERT, DELETE, UPDATE
-- Data Query Language : SELECT statement, use this to query your tables or find data in our tables

-- Normalization is a database design technique that helps to reduce data redundancy and improve data consistency

-- There are many normal forms that builds upon each other, but we normally use up to 3rd normal form
-- 1st Normal Form
-- All cells must have 0 or 1 data (atomicity)
-- All rows must be uniqguely identifiable (aka, must have a primary key)

-- 2nd Normal Form
-- It has to be in 1NF
-- It can't have Partial Dependency
    -- Partial Dependency is when a NON-KEY column depends on only one part of the key
-- The fastest way to achieve @NF, is to be in 1NF, and not have a composite key

-- 3rd Normal Form
-- 2NF
-- It can't have transitive dependency between non-key columns
    -- (if A => B and B => c then A => C)

-- The data in the table has to have a key (1NF), depend on the whole key (2NF), and nothing but the key (3NF)

-- Key
-- When we use more than 1 column to uniquely id a row, we call that a composite key

-- The easiest way to design a db that satisfies normal forms is to start from cardinality between entities
-- Workout - Exercises
-- 1 - many

-- Human - Pet
-- 1 - many

-- monogamous relationship
-- human - human
-- 1 - 1

-- trainer - associate
-- Many - Many

-- Professor - student
-- many - many

-- In implementing 1 - many
-- create two tables, with foreign reference of One in the Many table
-- Workout - Exercies
-- Foreign key refernce for workout table in Exercise table

-- User - Pet
-- User table and pets table
-- user table has foreign key reference to pets
drop table users;
drop table pets;

Create Table Users(
    id INTEGER primary key identity,
    name varchar(max),
)

create table pets(
    id int primary key IDENTITY,
    name varchar(max),
    userId int FOREIGN key references users(id)
)

INSERT into pets(name) values('auryn');
select * from pets;
INSERT into Users(name, petID) values('juniper', 'richard');
select * from users;

insert into pets(name) values ('fenris', 2), ('merry', 2), ('remington, 2'), ('claude', 2);
insert into users(name, petID) values ('richard', 5)