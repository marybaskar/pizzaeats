CREATE TABLE `user` (
    `user_id` SERIAL NOT NULL,
    `name` VARCHAR(60),
    `address` VARCHAR(60),
    `phone` VARCHAR(14),
    `username` VARCHAR(14),
    `password` VARCHAR(14),
    `email` VARCHAR(14),
    PRIMARY KEY (`id`)
);

CREATE TABLE `credit_card` (
    `cc_id` SERIAL,
    `name` VARCHAR(60),
    `number` VARCHAR(20),
    `expiration` DATE,
    PRIMARY KEY (`id`),
    UNIQUE (`name` , `number`)
);

CREATE TABLE `user_to_credit_card` (
    `user_id` INTEGER,
    `cc_id` INTEGER
);

CREATE TABLE `user_order` (
    `user_order_id` SERIAL,
    `user_id` INTEGER,
    `cc_id` INTEGER,
    `total_price` DOUBLE,
    PRIMARY KEY (`id`)
);

CREATE TABLE `user_to_order` (
    `user_id` INTEGER,
    `user_order_id` INTEGER
);


CREATE TABLE `pizzas` (
    `pizza_id` SERIAL,
    `size` VARCHAR(2),
    `topping_1` VARCHAR(20),
    `topping_2` VARCHAR(20),
    `topping_3` VARCHAR(20),
    `topping_4` VARCHAR(20),
    PRIMARY KEY (`id`)
);

CREATE TABLE `user_pizzas` (
    `user_order_id` INTEGER,
    `pizza_id` INTEGER
);

CREATE TABLE `toppings` (
    `name` VARCHAR(20),
    `price` DOUBLE,
    PRIMARY KEY (`name`)
);

CREATE TABLE `sizes` (
    `name` VARCHAR(2),
    `price` DOUBLE,
    PRIMARY KEY (`name`)
);

ALTER TABLE `user_credit_card` ADD FOREIGN KEY (`user_id`) REFERENCES `user` (`user_id`);
ALTER TABLE `user_credit_card` ADD FOREIGN KEY (`cc_id`) REFERENCES `credit_card` (`cc_id`);
ALTER TABLE `user_order` ADD FOREIGN KEY (`user_id`) REFERENCES `user` (`user_id`);
ALTER TABLE `user_order` ADD FOREIGN KEY (`cc_id`) REFERENCES `credit_card` (`cc_id`);
ALTER TABLE `user_order_preference` ADD FOREIGN KEY (`user_id`) REFERENCES `user` (`user_id`);
ALTER TABLE `user_order_preference` ADD FOREIGN KEY (`user_order_id`) REFERENCES `user_order` (`user_order_id`);
ALTER TABLE `pizzas` ADD FOREIGN KEY (`size`) REFERENCES `sizes` (`name`);
ALTER TABLE `pizzas` ADD FOREIGN KEY (`topping_1`) REFERENCES `toppings` (`name`);
ALTER TABLE `pizzas` ADD FOREIGN KEY (`topping_2`) REFERENCES `toppings` (`name`);
ALTER TABLE `pizzas` ADD FOREIGN KEY (`topping_3`) REFERENCES `toppings` (`name`);
ALTER TABLE `pizzas` ADD FOREIGN KEY (`topping_4`) REFERENCES `toppings` (`name`);
ALTER TABLE `user_pizzas` ADD FOREIGN KEY (`user_order_id`) REFERENCES `user_order` (`user_order_id`);
ALTER TABLE `user_pizzas` ADD FOREIGN KEY (`pizza_id`) REFERENCES `pizzas` (`pizza_id`);
ALTER TABLE `user_drinks` ADD FOREIGN KEY (`user_order_id`) REFERENCES `user_order` (`user_order_id`);

INSERT INTO "toppings" ( "name", "price" ) VALUES ( 'Chicken', 1 );
INSERT INTO "toppings" ( "name", "price" ) VALUES ( 'Shrimp', 1 );
INSERT INTO "toppings" ( "name", "price" ) VALUES ( 'Turkey', 1 );
INSERT INTO "toppings" ( "name", "price" ) VALUES ( 'Lamb', 1 );
INSERT INTO "toppings" ( "name", "price" ) VALUES ( 'Steak', 1 );

INSERT INTO "toppings" ( "name", "price" ) VALUES ( 'Mushrooms', .50 );
INSERT INTO "toppings" ( "name", "price" ) VALUES ( 'Spinach', .50 );
INSERT INTO "toppings" ( "name", "price" ) VALUES ( 'Olives', .50 );
INSERT INTO "toppings" ( "name", "price" ) VALUES ( 'Peppers', .50 );
INSERT INTO "toppings" ( "name", "price" ) VALUES ( 'Feta Cheese', .50 );

INSERT INTO "toppings" ( "name", "price" ) VALUES ( 'BBQ', .25 );
INSERT INTO "toppings" ( "name", "price" ) VALUES ( 'Blue Cheese', .25 );
INSERT INTO "toppings" ( "name", "price" ) VALUES ( 'Mozzarella', .25 );
INSERT INTO "toppings" ( "name", "price" ) VALUES ( 'Cheddar Cheese', .25 );
INSERT INTO "toppings" ( "name", "price" ) VALUES ( 'Pepper Jack', .25 );

INSERT INTO "sizes" ( "name", "price" ) VALUES ( 'S', 10 );
INSERT INTO "sizes" ( "name", "price" ) VALUES ( 'M', 12 );
INSERT INTO "sizes" ( "name", "price" ) VALUES ( 'L', 14 );
