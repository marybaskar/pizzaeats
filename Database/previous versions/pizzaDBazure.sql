CREATE TABLE users (
    user_id INT IDENTITY PRIMARY KEY,
    name NVARCHAR(60),
    address NVARCHAR(60),
    phone NVARCHAR(14),
    username NVARCHAR(14),
    password NVARCHAR(14),
    email NVARCHAR(30),
    
)

CREATE TABLE credit_card (
    cc_id INT IDENTITY PRIMARY KEY,
    name NVARCHAR(60),
    number NVARCHAR(20),
    expiration DATE,
    CONSTRAINT [UQ_creditcards] UNIQUE CLUSTERED
    (name , number)
)

CREATE TABLE user_to_credit_card (
    user_id INT REFERENCES users(user_id),
    cc_id INT REFERENCES credit_card(cc_id)
)

CREATE TABLE user_order (
    user_order_id INT IDENTITY PRIMARY KEY,
    user_id INT REFERENCES users(user_id),
    cc_id INT REFERENCES credit_card(cc_id),
    total_price DECIMAL(3,2)
)

CREATE TABLE user_to_order (
    user_id INT REFERENCES users(user_id),
    user_order_id INT REFERENCES user_order(user_order_id)
)


CREATE TABLE pizzas (
    pizza_id INT IDENTITY PRIMARY KEY,
    size NVARCHAR(2),
    topping_1 NVARCHAR(20 REFERENCES toppings(name)),
    topping_2 NVARCHAR(20) REFERENCES toppings(name),
    topping_3 NVARCHAR(20) REFERENCES toppings(name),
    topping_4 NVARCHAR(20) REFERENCES toppings(name)
)

CREATE TABLE user_pizzas (
    user_order_id INT REFERENCES user_order(user_order_id),
    pizza_id INT REFERENCES pizzas(pizza_id)
)

CREATE TABLE toppings (
    name NVARCHAR(20) PRIMARY KEY,
    price DECIMAL(3,2)
)

CREATE TABLE sizes (
    name NVARCHAR(2) PRIMARY KEY,
    price DECIMAL(3,2)
)

INSERT INTO toppings VALUES 
( 'Chicken', 1),
('Shrimp', 1  ),
( 'Turkey', 1 ),
( 'Lamb', 1 ),
( 'Steak', 1 ),
( 'Mushrooms', .50 ),
( 'Spinach', .50 ),
( 'Olives', .50 ),
( 'Peppers', .50 ),
( 'Feta Cheese', .50 ),
( 'BBQ', .25 ),
( 'Blue Cheese', .25 ),
( 'Mozzarella', .25 ),
( 'Cheddar Cheese', .25 ),
( 'Pepper Jack', .25 );


INSERT INTO sizes VALUES
( 'S', 10 ),
( 'M', 12 ),
( 'L', 14 ),
( 'XL', 16 );