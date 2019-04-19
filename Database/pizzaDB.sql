-- phpMyAdmin SQL Dump
-- version 4.8.3
-- https://www.phpmyadmin.net/
--
-- Host: localhost:3306
-- Generation Time: Apr 18, 2019 at 11:57 AM
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
-- Table structure for table `pizza`
--

CREATE TABLE `pizza` (
  `pizza_id` int(11) NOT NULL,
  `size` varchar(2) DEFAULT NULL,
  `cheese_topping` int(1) DEFAULT NULL,
  `meat_topping` int(1) DEFAULT NULL,
  `veg_topping` int(1) DEFAULT NULL
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
-- Table structure for table `topping_cheese`
--

CREATE TABLE `topping_cheese` (
  `t_id` int(1) NOT NULL,
  `name` varchar(20) NOT NULL,
  `price` double DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `topping_cheese`
--

INSERT INTO `topping_cheese` (`t_id`, `name`, `price`) VALUES
(1, 'Blue Cheese', 0.25),
(2, 'Feta', 0.25),
(3, 'Mozzarella', 0.25),
(4, 'Pepper Jack', 0.25);

-- --------------------------------------------------------

--
-- Table structure for table `topping_meat`
--

CREATE TABLE `topping_meat` (
  `t_id` int(1) NOT NULL,
  `name` varchar(20) NOT NULL,
  `price` double DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `topping_meat`
--

INSERT INTO `topping_meat` (`t_id`, `name`, `price`) VALUES
(1, 'Chicken', 1),
(2, 'Lamb', 1),
(3, 'Shrimp', 1),
(4, 'Steak', 1),
(5, 'Turkey', 1);

-- --------------------------------------------------------

--
-- Table structure for table `topping_veg`
--

CREATE TABLE `topping_veg` (
  `t_id` int(1) NOT NULL,
  `name` varchar(20) NOT NULL,
  `price` double DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `topping_veg`
--

INSERT INTO `topping_veg` (`t_id`, `name`, `price`) VALUES
(1, 'Mushrooms', 0.5),
(2, 'Olives', 0.5),
(3, 'Peppers', 0.5),
(4, 'Spinach', 0.5);

-- --------------------------------------------------------

--
-- Table structure for table `user`
--

CREATE TABLE `user` (
  `user_id` int(11) NOT NULL,
  `username` varchar(14) DEFAULT NULL,
  `password` varchar(14) DEFAULT NULL,
  `firstname` varchar(60) DEFAULT NULL,
  `lastname` varchar(60) DEFAULT NULL,
  `address` varchar(60) DEFAULT NULL,
  `phone` varchar(14) DEFAULT NULL,
  `email` varchar(14) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `user_order`
--

CREATE TABLE `user_order` (
  `user_id` int(11) NOT NULL,
  `pizza_id` int(11) NOT NULL,
  `total` decimal(5,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `user_to_credit_card`
--

CREATE TABLE `user_to_credit_card` (
  `user_id` int(11) NOT NULL,
  `cc_id` int(11) NOT NULL
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
-- Indexes for table `pizza`
--
ALTER TABLE `pizza`
  ADD PRIMARY KEY (`pizza_id`),
  ADD KEY `size` (`size`),
  ADD KEY `pizzas_ibfk_2` (`cheese_topping`),
  ADD KEY `pizzas_ibfk_3` (`meat_topping`),
  ADD KEY `pizzas_ibfk_4` (`veg_topping`);

--
-- Indexes for table `sizes`
--
ALTER TABLE `sizes`
  ADD PRIMARY KEY (`name`);

--
-- Indexes for table `topping_cheese`
--
ALTER TABLE `topping_cheese`
  ADD PRIMARY KEY (`t_id`);

--
-- Indexes for table `topping_meat`
--
ALTER TABLE `topping_meat`
  ADD PRIMARY KEY (`t_id`);

--
-- Indexes for table `topping_veg`
--
ALTER TABLE `topping_veg`
  ADD PRIMARY KEY (`t_id`);

--
-- Indexes for table `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`user_id`);

--
-- Indexes for table `user_order`
--
ALTER TABLE `user_order`
  ADD KEY `user_id` (`user_id`),
  ADD KEY `pizza_id` (`pizza_id`);

--
-- Indexes for table `user_to_credit_card`
--
ALTER TABLE `user_to_credit_card`
  ADD KEY `user_id` (`user_id`),
  ADD KEY `cc_id` (`cc_id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `credit_card`
--
ALTER TABLE `credit_card`
  MODIFY `cc_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `pizza`
--
ALTER TABLE `pizza`
  MODIFY `pizza_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `topping_cheese`
--
ALTER TABLE `topping_cheese`
  MODIFY `t_id` int(1) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `topping_meat`
--
ALTER TABLE `topping_meat`
  MODIFY `t_id` int(1) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `topping_veg`
--
ALTER TABLE `topping_veg`
  MODIFY `t_id` int(1) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `user`
--
ALTER TABLE `user`
  MODIFY `user_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `pizza`
--
ALTER TABLE `pizza`
  ADD CONSTRAINT `pizza_ibfk_1` FOREIGN KEY (`size`) REFERENCES `sizes` (`name`),
  ADD CONSTRAINT `pizza_ibfk_2` FOREIGN KEY (`cheese_topping`) REFERENCES `topping_cheese` (`t_id`),
  ADD CONSTRAINT `pizza_ibfk_3` FOREIGN KEY (`meat_topping`) REFERENCES `topping_meat` (`t_id`),
  ADD CONSTRAINT `pizza_ibfk_4` FOREIGN KEY (`veg_topping`) REFERENCES `topping_veg` (`t_id`);

--
-- Constraints for table `user_order`
--
ALTER TABLE `user_order`
  ADD CONSTRAINT `user_order_ibfk_1` FOREIGN KEY (`user_id`) REFERENCES `user` (`user_id`);

--
-- Constraints for table `user_to_credit_card`
--
ALTER TABLE `user_to_credit_card`
  ADD CONSTRAINT `user_to_credit_card_ibfk_1` FOREIGN KEY (`user_id`) REFERENCES `user` (`user_id`),
  ADD CONSTRAINT `user_to_credit_card_ibfk_2` FOREIGN KEY (`cc_id`) REFERENCES `credit_card` (`cc_id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
