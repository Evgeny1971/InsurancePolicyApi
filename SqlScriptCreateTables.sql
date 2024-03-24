-- Create Users table
CREATE TABLE Users (
    ID INTEGER PRIMARY KEY,
    Name TEXT,
    Email TEXT
);


-- Create InsurancePolicies table
CREATE TABLE InsurancePolicies (
    ID INTEGER PRIMARY KEY,
    PolicyNumber TEXT,
    InsuranceAmount REAL,
    StartDate DATE,
    EndDate DATE,
    UserID INTEGER,
    FOREIGN KEY (UserID) REFERENCES Users(ID)
);
