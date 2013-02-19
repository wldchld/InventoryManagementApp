-- Creator:       MySQL Workbench 5.2.46/ExportSQLite plugin 2009.12.02
-- Author:        ville
-- Caption:       New Model
-- Project:       Name of the project
-- Changed:       2013-02-19 14:11
-- Created:       2013-02-11 19:44
PRAGMA foreign_keys = OFF;

-- Schema: mydb
BEGIN;
CREATE TABLE "Unit"(
  "UnitID" INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
  "UnitName" VARCHAR(45) NOT NULL,
  "BaseUnitID" INTEGER NOT NULL,
  "Factor" FLOAT NOT NULL,
  "IsSI" BOOLEAN NOT NULL,
  "Type" INTEGER NOT NULL
);
CREATE TABLE "Recipe"(
  "RecipeID" INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
  "RecipeName" VARCHAR(45)
);
CREATE TABLE "ShoppingList"(
  "ShoppingLIstID" INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
  "ShoppingListName" VARCHAR(45) NOT NULL
);
CREATE TABLE "Material"(
  "MaterialID" INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
  "MaterialName" VARCHAR(45) NOT NULL,
  "UnitID" INTEGER NOT NULL,
  "Group" VARCHAR(45) NOT NULL,
  "Infinite" BOOLEAN NOT NULL,
  "Info" VARCHAR(200),
  "Date" DATE,
  CONSTRAINT "fk_Material_Unit1"
    FOREIGN KEY("UnitID")
    REFERENCES "Unit"("UnitID")
);
CREATE INDEX "Material.fk_Material_Unit1_idx" ON "Material"("UnitID");
CREATE TABLE "Inventory"(
  "RecID" INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
  "Amount" INTEGER NOT NULL,
  "MaterialID" INTEGER NOT NULL,
  CONSTRAINT "fk_Inventory_Material"
    FOREIGN KEY("MaterialID")
    REFERENCES "Material"("MaterialID")
);
CREATE INDEX "Inventory.fk_Inventory_Material_idx" ON "Inventory"("MaterialID");
CREATE TABLE "RecipeEntry"(
  "RecID" INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
  "RecipeID" INTEGER NOT NULL,
  "Amount" INTEGER,
  "MaterialID" INTEGER NOT NULL,
  CONSTRAINT "fk_RecipeContent_Recipe1"
    FOREIGN KEY("RecipeID")
    REFERENCES "Recipe"("RecipeID"),
  CONSTRAINT "fk_RecipeContent_Material1"
    FOREIGN KEY("MaterialID")
    REFERENCES "Material"("MaterialID")
);
CREATE INDEX "RecipeEntry.fk_RecipeContent_Recipe1_idx" ON "RecipeEntry"("RecipeID");
CREATE INDEX "RecipeEntry.fk_RecipeContent_Material1_idx" ON "RecipeEntry"("MaterialID");
CREATE TABLE "ShoppingListEntry"(
  "RecID" INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
  "ShoppingLIstID" INTEGER NOT NULL,
  "MaterialID" INTEGER NOT NULL,
  "Amount" INTEGER,
  CONSTRAINT "fk_ShoppingListContent_ShoppingList1"
    FOREIGN KEY("ShoppingLIstID")
    REFERENCES "ShoppingList"("ShoppingLIstID"),
  CONSTRAINT "fk_ShoppingListContent_Material1"
    FOREIGN KEY("MaterialID")
    REFERENCES "Material"("MaterialID")
);
CREATE INDEX "ShoppingListEntry.fk_ShoppingListContent_ShoppingList1_idx" ON "ShoppingListEntry"("ShoppingLIstID");
CREATE INDEX "ShoppingListEntry.fk_ShoppingListContent_Material1_idx" ON "ShoppingListEntry"("MaterialID");
COMMIT;
