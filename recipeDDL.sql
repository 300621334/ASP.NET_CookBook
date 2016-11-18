 
 --===============================================================
 create table categories
 (
 category varchar(15)
 );

  insert into categories (category)
 values ('Beverage'),('Main Course'),('Desert'),('Appetizer');
 

 --===============================================================
 create table recipes
 (
 recipeName	varchar(30),
 fromName		varchar(30),
 cookingTime	varchar(3),
 portions		varchar(3),
 category		varchar(15),
 cuisine		varchar(15),
 private		varchar(1),
 description	varchar(500)
 );

  insert into recipes (recipeName,fromName,cookingTime,portions,category,cuisine,private,description)
 values ('Tea',	'Mani',	'5', '1', 'Beverage','Asian','0','This is how you make a cup of tea'),
 ('cookie',	'Zoya',	'30', '4', 'Main Course','Asian','0','This is how you make it'),
 ('Meat Loaf',	'Arham','45', '3', 'Main Course','Asian','0','This is how you make it'),
 ('Samosa',	'Yasmin',	'45', '4', 'Appetizer','Asian','0','This is how you make it')
 ;
 --===============================================================
