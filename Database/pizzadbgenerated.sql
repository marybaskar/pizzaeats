-- phpMyAdmin SQL Dump
-- version 4.8.3
-- https://www.phpmyadmin.net/
--
-- Host: localhost:3306
-- Generation Time: Apr 10, 2019 at 05:04 PM
-- Server version: 5.7.24
-- PHP Version: 7.1.24

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `pizzadb`
--

-- --------------------------------------------------------

--
-- Table structure for table `credit_card`
--

CREATE TABLE `credit_card` (
  `cc_id` int(11) NOT NULL,
  `name` varchar(60) DEFAULT NULL,
  `number` varchar(20) DEFAULT NULL,
  `expiration` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `pizzas`
--

CREATE TABLE `pizzas` (
  `pizza_id` int(11) NOT NULL,
  `size` varchar(2) DEFAULT NULL,
  `topping_1` varchar(20) DEFAULT NULL,
  `topping_2` varchar(20) DEFAULT NULL,
  `topping_3` varchar(20) DEFAULT NULL,
  `topping_4` varchar(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `sizes`
--

CREATE TABLE `sizes` (
  `name` varchar(2) NOT NULL,
  `price` double DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `sizes`
--

INSERT INTO `sizes` (`name`, `price`) VALUES
('L', 14),
('M', 12),
('S', 10);

-- --------------------------------------------------------

--
-- Table structure for table `toppings`
--

CREATE TABLE `toppings` (
  `name` varchar(20) NOT NULL,
  `price` double DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `toppings`
--

INSERT INTO `toppings` (`name`, `price`) VALUES
('BBQ', 0.25),
('Blue Cheese', 0.25),
('Cheddar Cheese', 0.25),
('Chicken', 1),
('Feta Cheese', 0.5),
('Lamb', 1),
('Mozzarella', 0.25),
('Mushrooms', 0.5),
('Olives', 0.5),
('Pepper Jack', 0.25),
('Peppers', 0.5),
('Shrimp', 1),
('Spinach', 0.5),
('Steak', 1),
('Turkey', 1);

-- --------------------------------------------------------

--
-- Table structure for table `user`
--

CREATE TABLE `user` (
  `user_id` int(11) NOT NULL,
  `name` varchar(60) DEFAULT NULL,
  `address` varchar(60) DEFAULT NULL,
  `phone` varchar(14) DEFAULT NULL,
  `username` varchar(14) DEFAULT NULL,
  `password` varchar(14) DEFAULT NULL,
  `email` varchar(14) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `user_order_to_pizzas`
--

CREATE TABLE `user_order_to_pizzas` (
  `user_order_id` int(11) NOT NULL,
  `pizza_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `user_order_user_cc`
--

CREATE TABLE `user_order_user_cc` (
  `user_order_id` int(11) NOT NULL,
  `user_id` int(11) NOT NULL,
  `cc_id` int(11) NOT NULL,
  `total_price` double DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `user_to_credit_card`
--

CREATE TABLE `user_to_credit_card` (
  `user_id` int(11) NOT NULL,
  `cc_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `user_to_order`
--

CREATE TABLE `user_to_order` (
  `user_id` int(11) NOT NULL,
  `user_order_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `credit_card`
--
ALTER TABLE `credit_card`
  ADD PRIMARY KEY (`cc_id`),
  ADD UNIQUE KEY `name` (`name`,`number`);

--
-- Indexes for table `pizzas`
--
ALTER TABLE `pizzas`
  ADD PRIMARY KEY (`pizza_id`),
  ADD KEY `size` (`size`),
  ADD KEY `topping_1` (`topping_1`),
  ADD KEY `topping_2` (`topping_2`),
  ADD KEY `topping_3` (`topping_3`),
  ADD KEY `topping_4` (`topping_4`);

--
-- Indexes for table `sizes`
--
ALTER TABLE `sizes`
  ADD PRIMARY KEY (`name`);

--
-- Indexes for table `toppings`
--
ALTER TABLE `toppings`
  ADD PRIMARY KEY (`name`);

--
-- Indexes for table `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`user_id`);

--
-- Indexes for table `user_order_to_pizzas`
--
ALTER TABLE `user_order_to_pizzas`
  ADD KEY `user_order_id` (`user_order_id`),
  ADD KEY `pizza_id` (`pizza_id`);

--
-- Indexes for table `user_order_user_cc`
--
ALTER TABLE `user_order_user_cc`
  ADD PRIMARY KEY (`user_order_id`),
  ADD KEY `user_id` (`user_id`),
  ADD KEY `cc_id` (`cc_id`);

--
-- Indexes for table `user_to_credit_card`
--
ALTER TABLE `user_to_credit_card`
  ADD KEY `user_id` (`user_id`),
  ADD KEY `cc_id` (`cc_id`);

--
-- Indexes for table `user_to_order`
--
ALTER TABLE `user_to_order`
  ADD KEY `user_id` (`user_id`),
  ADD KEY `user_order_id` (`user_order_id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `credit_card`
--
ALTER TABLE `credit_card`
  MODIFY `cc_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `pizzas`
--
ALTER TABLE `pizzas`
  MODIFY `pizza_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `user`
--
ALTER TABLE `user`
  MODIFY `user_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `user_order_user_cc`
--
ALTER TABLE `user_order_user_cc`
  MODIFY `user_order_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `pizzas`
--
ALTER TABLE `pizzas`
  ADD CONSTRAINT `pizzas_ibfk_1` FOREIGN KEY (`size`) REFERENCES `sizes` (`name`),
  ADD CONSTRAINT `pizzas_ibfk_2` FOREIGN KEY (`topping_1`) REFERENCES `toppings` (`name`),
  ADD CONSTRAINT `pizzas_ibfk_3` FOREIGN KEY (`topping_2`) REFERENCES `toppings` (`name`),
  ADD CONSTRAINT `pizzas_ibfk_4` FOREIGN KEY (`topping_3`) REFERENCES `toppings` (`name`),
  ADD CONSTRAINT `pizzas_ibfk_5` FOREIGN KEY (`topping_4`) REFERENCES `toppings` (`name`);

--
-- Constraints for table `user_order_to_pizzas`
--
ALTER TABLE `user_order_to_pizzas`
  ADD CONSTRAINT `user_order_to_pizzas_ibfk_1` FOREIGN KEY (`user_order_id`) REFERENCES `user` (`user_id`),
  ADD CONSTRAINT `user_order_to_pizzas_ibfk_2` FOREIGN KEY (`pizza_id`) REFERENCES `pizzas` (`pizza_id`);

--
-- Constraints for table `user_order_user_cc`
--
ALTER TABLE `user_order_user_cc`
  ADD CONSTRAINT `user_order_user_cc_ibfk_1` FOREIGN KEY (`user_id`) REFERENCES `user` (`user_id`),
  ADD CONSTRAINT `user_order_user_cc_ibfk_2` FOREIGN KEY (`cc_id`) REFERENCES `credit_card` (`cc_id`);

--
-- Constraints for table `user_to_credit_card`
--
ALTER TABLE `user_to_credit_card`
  ADD CONSTRAINT `user_to_credit_card_ibfk_1` FOREIGN KEY (`user_id`) REFERENCES `user` (`user_id`),
  ADD CONSTRAINT `user_to_credit_card_ibfk_2` FOREIGN KEY (`cc_id`) REFERENCES `credit_card` (`cc_id`);

--
-- Constraints for table `user_to_order`
--
ALTER TABLE `user_to_order`
  ADD CONSTRAINT `user_to_order_ibfk_1` FOREIGN KEY (`user_id`) REFERENCES `user` (`user_id`),
  ADD CONSTRAINT `user_to_order_ibfk_2` FOREIGN KEY (`user_order_id`) REFERENCES `user_order_user_cc` (`user_order_id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
