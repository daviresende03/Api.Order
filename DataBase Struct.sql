SET FOREIGN_KEY_CHECKS=0;

DROP TABLE IF EXISTS `Client`;
CREATE TABLE `Client` (
  `id` int(6) PRIMARY KEY AUTO_INCREMENT,
  `name` varchar(32) NOT NULL,
  `email` varchar(100) NOT NULL,
  `phoneNumber` varchar(14) NOT NULL,
  `adress` varchar(200) NOT NULL,
  `createdAt` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS `User`;
CREATE TABLE `User` (
  `id` int(6) PRIMARY KEY AUTO_INCREMENT,
  `name` varchar(100) NOT NULL,
  `login` varchar(20) NOT NULL,
  `passWordHash` varchar(255) NOT NULL,
  `createdAt` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS `Order`;
CREATE TABLE `Order` (
  `id` int(6) PRIMARY KEY AUTO_INCREMENT,
  `client_id` int(6) NOT NULL,
  `user_id` int(6) NOT NULL,
  `createdAt` date NOT NULL,
  KEY `client_id` (`client_id`),
  KEY `user_id` (`user_id`),
  CONSTRAINT `client_id` FOREIGN KEY (`client_id`) REFERENCES `Client` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `user_id` FOREIGN KEY (`user_id`) REFERENCES `User` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS `OrderItem`;
CREATE TABLE `OrderItem` (
  `id` int(6) PRIMARY KEY AUTO_INCREMENT,
  `order_id` int(6) NOT NULL,
  `product_id` int(6) NOT NULL,
  `sellValue` decimal(10,2) NOT NULL,
  `quantity` decimal(18,0) NOT NULL,
  `totalAmount` decimal(10,2) NOT NULL,
  `createdAt` date NOT NULL,
  KEY `order_id` (`order_id`),
  KEY `product_id` (`product_id`),
  CONSTRAINT `order_id` FOREIGN KEY (`order_id`) REFERENCES `Order` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `product_id` FOREIGN KEY (`product_id`) REFERENCES `Product` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS `Product`;
CREATE TABLE `Product` (
  `id` int(6) PRIMARY KEY AUTO_INCREMENT,
  `description` varchar(100) NOT NULL,
  `sellValue` decimal(10,2) NOT NULL,
  `stock` int NOT NULL,
  `createdAt` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

SET FOREIGN_KEY_CHECKS=1;