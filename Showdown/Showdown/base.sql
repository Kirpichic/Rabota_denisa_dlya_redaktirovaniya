-- MySQL dump 10.13  Distrib 8.0.28, for Win64 (x86_64)
--
-- Host: localhost    Database: obshaga
-- ------------------------------------------------------
-- Server version	8.0.23

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `rooms`
--

DROP TABLE IF EXISTS `rooms`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `rooms` (
  `Room_num` int NOT NULL,
  `FIO` varchar(45) NOT NULL,
  `Status` varchar(45) NOT NULL,
  `Vil_count` int NOT NULL,
  `Vil_max` int NOT NULL,
  `Traety_num` int NOT NULL AUTO_INCREMENT,
  `Zaselenie_date` varchar(45) NOT NULL,
  `Vyselenie_date` varchar(45) NOT NULL,
  PRIMARY KEY (`Traety_num`)
) ENGINE=InnoDB AUTO_INCREMENT=38 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `rooms`
--

LOCK TABLES `rooms` WRITE;
/*!40000 ALTER TABLE `rooms` DISABLE KEYS */;
INSERT INTO `rooms` VALUES (1,'Viktor Korneplod','smotrila',2,4,33,'14.4.2022','0'),(1,'Valery Albertovich','smotrila',4,4,35,'14.4.2022','0'),(1,'Stas Stuya','shnir',3,4,36,'14.4.2022','0'),(1,'Sergey Petrovich','Student',3,4,37,'14.4.2022','0');
/*!40000 ALTER TABLE `rooms` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `zhitelxrooms`
--

DROP TABLE IF EXISTS `zhitelxrooms`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `zhitelxrooms` (
  `Room_num` int NOT NULL AUTO_INCREMENT,
  `Vil_max` varchar(45) NOT NULL,
  PRIMARY KEY (`Room_num`)
) ENGINE=InnoDB AUTO_INCREMENT=53 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `zhitelxrooms`
--

LOCK TABLES `zhitelxrooms` WRITE;
/*!40000 ALTER TABLE `zhitelxrooms` DISABLE KEYS */;
INSERT INTO `zhitelxrooms` VALUES (1,'4'),(2,'2'),(3,'2'),(4,'4'),(5,'4'),(6,'2'),(7,'2'),(8,'4'),(9,'4'),(10,'2'),(11,'2'),(12,'4'),(13,'4'),(14,'2'),(15,'2'),(16,'4'),(17,'4'),(18,'2'),(19,'2'),(20,'4'),(21,'4'),(22,'2'),(23,'2'),(24,'4'),(25,'4'),(26,'2'),(27,'2'),(28,'4'),(29,'4'),(30,'2'),(31,'2'),(32,'4'),(33,'4'),(34,'2'),(35,'2'),(36,'4'),(37,'4'),(38,'2'),(39,'2'),(40,'4'),(41,'4'),(42,'2'),(43,'2'),(44,'4'),(45,'4'),(46,'2'),(47,'2'),(48,'4'),(49,'4'),(50,'2');
/*!40000 ALTER TABLE `zhitelxrooms` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-04-14 16:10:45
