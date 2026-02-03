-- Created by Redgate Data Modeler (https://datamodeler.redgate-platform.com)
-- Last modification date: 2026-01-26 02:57:38.172

-- tables
-- Table: Budget
CREATE TABLE Budget (
    User_ID int  NOT NULL,
    MonthlyLimit money  NOT NULL,
    Category_ID int  NOT NULL,
    Month int  NOT NULL,
    Year int  NOT NULL,
    Budget_ID int  NOT NULL,
    CONSTRAINT chk_budget_month CHECK (Month BETWEEN 1 and 12) NOT DEFERRABLE INITIALLY IMMEDIATE,
    CONSTRAINT chk_budget_year CHECK (Year >= 2000 AND Year <= 2100) NOT DEFERRABLE INITIALLY IMMEDIATE,
    CONSTRAINT Budget_pk PRIMARY KEY (Budget_ID)
);

-- Table: Category
CREATE TABLE Category (
    Category_ID int  NOT NULL,
    Category_Name varchar(52)  NOT NULL,
    Category_Color varchar(7)  NOT NULL,
    CONSTRAINT Category_pk PRIMARY KEY (Category_ID)
);

-- Table: RecurringTransaction
CREATE TABLE RecurringTransaction (
    Category_ID int  NOT NULL,
    User_ID int  NOT NULL,
    Amount money  NOT NULL,
    Frequency varchar(10)  NOT NULL,
    NextOccurence date  NOT NULL,
    RecurringTransaction_ID int  NOT NULL,
    CONSTRAINT Frequency CHECK (Frequency IN ('Daily', 'Weekly', 'Monthly', 'Yearly')) NOT DEFERRABLE INITIALLY IMMEDIATE,
    CONSTRAINT RecurringTransaction_pk PRIMARY KEY (RecurringTransaction_ID)
);

-- Table: Transaction
CREATE TABLE Transaction (
    Category_ID int  NOT NULL,
    Amount money  NOT NULL,
    User_ID int  NOT NULL,
    Date date  NOT NULL,
    Transaction_ID int  NOT NULL,
    CONSTRAINT Transaction_pk PRIMARY KEY (Transaction_ID)
);

-- Table: User
CREATE TABLE "User" (
    User_ID int  NOT NULL,
    Username varchar(52)  NOT NULL,
    password_hash varchar(100)  NOT NULL,
    salt varchar(100)  NOT NULL,
    created_at timestamp  NOT NULL,
    CONSTRAINT User_ID PRIMARY KEY (User_ID)
);

-- foreign keys
-- Reference: Budget_Category (table: Budget)
ALTER TABLE Budget ADD CONSTRAINT Budget_Category
    FOREIGN KEY (Category_ID)
    REFERENCES Category (Category_ID)  
    NOT DEFERRABLE 
    INITIALLY IMMEDIATE
;

-- Reference: Budget_User (table: Budget)
ALTER TABLE Budget ADD CONSTRAINT Budget_User
    FOREIGN KEY (User_ID)
    REFERENCES "User" (User_ID)  
    NOT DEFERRABLE 
    INITIALLY IMMEDIATE
;

-- Reference: RecurringTransaction_Category (table: RecurringTransaction)
ALTER TABLE RecurringTransaction ADD CONSTRAINT RecurringTransaction_Category
    FOREIGN KEY (Category_ID)
    REFERENCES Category (Category_ID)  
    NOT DEFERRABLE 
    INITIALLY IMMEDIATE
;

-- Reference: RecurringTransaction_User (table: RecurringTransaction)
ALTER TABLE RecurringTransaction ADD CONSTRAINT RecurringTransaction_User
    FOREIGN KEY (User_ID)
    REFERENCES "User" (User_ID)  
    NOT DEFERRABLE 
    INITIALLY IMMEDIATE
;

-- Reference: Transaction_Category (table: Transaction)
ALTER TABLE Transaction ADD CONSTRAINT Transaction_Category
    FOREIGN KEY (Category_ID)
    REFERENCES Category (Category_ID)  
    NOT DEFERRABLE 
    INITIALLY IMMEDIATE
;

-- Reference: Transaction_User (table: Transaction)
ALTER TABLE Transaction ADD CONSTRAINT Transaction_User
    FOREIGN KEY (User_ID)
    REFERENCES "User" (User_ID)  
    NOT DEFERRABLE 
    INITIALLY IMMEDIATE
;

-- End of file.

