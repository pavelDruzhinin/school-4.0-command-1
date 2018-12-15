delete from ItemGenres;
DBCC CHECKIDENT ('ItemGenres', RESEED, 0);
delete from Items;
DBCC CHECKIDENT ('Items', RESEED, 0);
delete from Genres;
DBCC CHECKIDENT ('Genres', RESEED, 0);
delete from Ratings;
DBCC CHECKIDENT ('Ratings', RESEED, 0);
delete from AspNetUsers;
