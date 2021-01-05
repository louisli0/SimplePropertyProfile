/****** Script for SelectTopNRows command from SSMS  ******/

UPDATE SimpleLibrary.dbo.BorrowedBooks
SET DueDate = '2020-09-07 11:59'
WHERE BorrowId = CAST('0B2CDB0C-04BD-41DD-8BAF-0E6BDDB5C2B8' AS uniqueidentifier);

DELETE FROM SimpleLibrary.dbo.Books;

INSERT INTO SimpleLibrary.dbo.Books (Author, PublishedYear, IsReferenceItem, ItemId, Name)
VALUES ('AuthorName', '2019', 0, NEWID(), 'Book Title');
