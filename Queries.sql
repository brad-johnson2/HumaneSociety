INSERT INTO Shots(Name)
VALUES ('Rabies'), ('Immunodeficiency'), ('Idenovirus'), ('Coronovirus'), ('Borrelia burgdorferi');

INSERT INTO Rooms(RoomNumber)
VALUES (101), (102), (103), (104), (105), (201), (202), (203), (204), (205);

INSERT INTO DietPlans(Name, FoodType, FoodAmountInCups)
VALUES ('Big Dog', 'Dog Food', 2);
INSERT INTO DietPlans(Name, FoodType, FoodAmountInCups)
VALUES ('Little Dog', 'Dog Food', 1);
INSERT INTO DietPlans(Name, FoodType, FoodAmountInCups)
VALUES ('Cat', 'Cat Food', .5);
INSERT INTO DietPlans(Name, FoodType, FoodAmountInCups)
VALUES ('Horse', 'Carrot', 6);
INSERT INTO DietPlans(Name, FoodType, FoodAmountInCups)
VALUES ('Llama', 'Corn', 3);

INSERT INTO Categories(Name)
VALUES ('Dog'), ('Cat'), ('Bird'), ('Lizard'), ('Chinchilla');

INSERT INTO Animals(Name, Weight, Age, Demeanor, KidFriendly, PetFriendly, Gender, AdoptionStatus)
VALUES ('Kona', 123, 5, 'Playful', 1, 1, 'Male', 'N');
INSERT INTO Animals(Name, Weight, Age, Demeanor, KidFriendly, PetFriendly, Gender, AdoptionStatus)
VALUES ('Nike', 79, 3, 'Excitable', 1, 0, 'Male', 'N');
INSERT INTO Animals(Name, Weight, Age, Demeanor, KidFriendly, PetFriendly, Gender, AdoptionStatus)
VALUES ('Yukon', 90, 10, 'Lazy', 1, 1, 'Female', 'Y');
INSERT INTO Animals(Name, Weight, Age, Demeanor, KidFriendly, PetFriendly, Gender, AdoptionStatus)
VALUES ('Coda', 102, 5, 'Crazy', 0, 1, 'Female', 'N');
INSERT INTO Animals(Name, Weight, Age, Demeanor, KidFriendly, PetFriendly, Gender, AdoptionStatus)
VALUES ('Kido', 65, 5, 'Loyal', 1, 1, 'Male', 'Y');

