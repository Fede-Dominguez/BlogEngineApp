CREATE TABLE BLOG (
  COD_BLOG INT IDENTITY(1,1) PRIMARY KEY,
  Title VARCHAR(100),
  Description VARCHAR(255),
  State VARCHAR(20),
  Author VARCHAR(50),
  Date DATE
);
