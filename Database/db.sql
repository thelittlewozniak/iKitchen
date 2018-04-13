-- -----------------------------------------------------
-- Table TypeUser
-- -----------------------------------------------------
CREATE TABLE TypeUser (
  idTypeUser INT NOT NULL IDENTITY(1,1),
  typeUserDesc VARCHAR(45) NULL ,
  PRIMARY KEY (idTypeUser)  
  );
-- -----------------------------------------------------
-- Table Schedule
-- -----------------------------------------------------
CREATE TABLE Schedule (
  idSchedule INT NOT NULL IDENTITY(1,1),
  PRIMARY KEY (idSchedule)  );
-- -----------------------------------------------------
-- Table user
-- -----------------------------------------------------
CREATE TABLE user (
  iduser INT NOT NULL IDENTITY(1,1),
  userUsername VARCHAR(45) NULL ,
  userEmail VARCHAR(45) NULL ,
  userPassword VARCHAR(45) NULL ,
  TypeUser_idTypeUser INT NOT NULL ,
  Schedule_idSchedule INT NOT NULL ,
  PRIMARY KEY (iduser)  ,
  INDEX fk_user_TypeUser_idx (TypeUser_idTypeUser ASC)  ,
  INDEX fk_user_Schedule1_idx (Schedule_idSchedule ASC)  ,
  CONSTRAINT fk_user_TypeUser
    FOREIGN KEY (TypeUser_idTypeUser)
    REFERENCES TypeUser (idTypeUser),
  CONSTRAINT fk_user_Schedule1
    FOREIGN KEY (Schedule_idSchedule)
    REFERENCES Schedule (idSchedule)
    );
-- -----------------------------------------------------
-- Table AvailableDate
-- -----------------------------------------------------
CREATE TABLE AvailableDate (
  idAvailableDate INT NOT NULL IDENTITY(1,1),
  date DATETIME NULL ,
  Schedule_idSchedule INT NOT NULL ,
  PRIMARY KEY (idAvailableDate)  ,
  INDEX fk_AvailableDate_Schedule1_idx (Schedule_idSchedule ASC)  ,
  CONSTRAINT fk_AvailableDate_Schedule1
    FOREIGN KEY (Schedule_idSchedule)
    REFERENCES Schedule (idSchedule)
    );
-- -----------------------------------------------------
-- Table Order
-- -----------------------------------------------------
CREATE TABLE Order (
  idOrder INT NOT NULL IDENTITY(1,1),
  orderDatetime DATETIME NULL ,
  orderAmount VARCHAR(45) NULL ,
  Schedule_idSchedule INT NOT NULL ,
  PRIMARY KEY (idOrder)  ,
  INDEX fk_Order_Schedule1_idx (Schedule_idSchedule ASC)  ,
  CONSTRAINT fk_Order_Schedule1
    FOREIGN KEY (Schedule_idSchedule)
    REFERENCES Schedule (idSchedule)
    );
-- -----------------------------------------------------
-- Table Thema
-- -----------------------------------------------------
CREATE TABLE Thema (
  idThema INT NOT NULL IDENTITY(1,1),
  ThemaName VARCHAR(45) NULL ,
  ThemaDesc VARCHAR(45) NULL ,
  PRIMARY KEY (idThema)  
  );
-- -----------------------------------------------------
-- Table Catalog
-- -----------------------------------------------------
CREATE TABLE Catalog (
  idCatalog INT NOT NULL IDENTITY(1,1),
  Thema_idThema INT NOT NULL ,
  PRIMARY KEY (idCatalog)  ,
  INDEX fk_Catalog_Thema1_idx (Thema_idThema ASC)  ,
  CONSTRAINT fk_Catalog_Thema1
    FOREIGN KEY (Thema_idThema)
    REFERENCES Thema (idThema)
    );
-- -----------------------------------------------------
-- Table TypeDish
-- -----------------------------------------------------
CREATE TABLE TypeDish (
  idTypeDish INT NOT NULL IDENTITY(1,1),
  typeDishName VARCHAR(45) NULL ,
  typeDishDesc VARCHAR(45) NULL ,
  PRIMARY KEY (idTypeDish)  
  );
-- -----------------------------------------------------
-- Table Dish
-- -----------------------------------------------------
CREATE TABLE Dish (
  idDish INT NOT NULL IDENTITY(1,1),
  dishPrice VARCHAR(45) NULL ,
  Catalog_idCatalog INT NOT NULL ,
  TypeDish_idTypeDish INT NOT NULL ,
  PRIMARY KEY (idDish)  ,
  INDEX fk_Dish_Catalog1_idx (Catalog_idCatalog ASC)  ,
  INDEX fk_Dish_TypeDish1_idx (TypeDish_idTypeDish ASC)  ,
  CONSTRAINT fk_Dish_Catalog1
    FOREIGN KEY (Catalog_idCatalog)
    REFERENCES Catalog (idCatalog),
  CONSTRAINT fk_Dish_TypeDish1
    FOREIGN KEY (TypeDish_idTypeDish)
    REFERENCES TypeDish (idTypeDish)
    );
-- -----------------------------------------------------
-- Table Comment
-- -----------------------------------------------------
CREATE TABLE Comment (
  idComment INT NOT NULL IDENTITY(1,1),
  commentText VARCHAR(45) NULL ,
  user_iduser INT NOT NULL ,
  Dish_idDish INT NOT NULL ,
  PRIMARY KEY (idComment)  ,
  INDEX fk_Comment_user1_idx (user_iduser ASC)  ,
  INDEX fk_Comment_Dish1_idx (Dish_idDish ASC)  ,
  CONSTRAINT fk_Comment_user1
    FOREIGN KEY (user_iduser)
    REFERENCES user (iduser),
  CONSTRAINT fk_Comment_Dish1
    FOREIGN KEY (Dish_idDish)
    REFERENCES Dish (idDish)
    );
-- -----------------------------------------------------
-- Table Ingredient
-- -----------------------------------------------------
CREATE TABLE Ingredient (
  idIngredient INT NOT NULL IDENTITY(1,1),
  IngredientName VARCHAR(45) NULL ,
  Dish_idDish INT NOT NULL ,
  PRIMARY KEY (idIngredient)  ,
  INDEX fk_Ingredient_Dish1_idx (Dish_idDish ASC)  ,
  CONSTRAINT fk_Ingredient_Dish1
    FOREIGN KEY (Dish_idDish)
    REFERENCES Dish (idDish)
    );
