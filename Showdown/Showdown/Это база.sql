-- MySQL dump 10.13  Distrib 8.0.28, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: obshaga
-- ------------------------------------------------------
-- Server version	8.0.28

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
-- Table structure for table `archive`
--

DROP TABLE IF EXISTS `archive`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `archive` (
  `Room_num` char(50) DEFAULT NULL,
  `FIO` text,
  `Status` text,
  `Vil_count` int DEFAULT NULL,
  `Vil_max` int DEFAULT NULL,
  `Treaty_num` int DEFAULT NULL,
  `Zaselenie_date` text,
  `Vyselenie_date` text
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `archive`
--

LOCK TABLES `archive` WRITE;
/*!40000 ALTER TABLE `archive` DISABLE KEYS */;
INSERT INTO `archive` VALUES ('1','Zubenko Michail Petrovich','Student',4,4,1,'',''),('1','1','1',1,1,4,'',''),('1','Viktor Korneplod','Student',2,4,5,'12.4.2022',''),('1','Rayan Gosling','jiv',4,4,6,'6.5.2022','0'),('2','Master Shifu','kung-fu',1,2,NULL,'10.5.2022','0'),('2','Bogomol Zelenyi','maloy',2,2,NULL,'10.5.2022','0');
/*!40000 ALTER TABLE `archive` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `rooms`
--

DROP TABLE IF EXISTS `rooms`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `rooms` (
  `Room_num` char(50) NOT NULL,
  `FIO` char(50) DEFAULT NULL,
  `Status` char(25) DEFAULT NULL,
  `Vil_count` int DEFAULT NULL,
  `Vil_max` int DEFAULT NULL,
  `Treaty_num` int NOT NULL AUTO_INCREMENT,
  `Zaselenie_date` varchar(45) NOT NULL,
  `Vyselenie_date` varchar(45) NOT NULL,
  PRIMARY KEY (`Treaty_num`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `rooms`
--

LOCK TABLES `rooms` WRITE;
/*!40000 ALTER TABLE `rooms` DISABLE KEYS */;
INSERT INTO `rooms` VALUES ('1','Zubenko Michail Petrovich','Student',4,4,1,'',''),('1','1','1',1,1,4,'',''),('1','Viktor Korneplod','Student',2,4,5,'12.4.2022',''),('1','Rayan Gosling','jiv',4,4,6,'6.5.2022','0'),('2','Master Shifu','kung-fu',1,2,7,'10.5.2022','0');
/*!40000 ALTER TABLE `rooms` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `zhitelxrooms`
--

DROP TABLE IF EXISTS `zhitelxrooms`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `zhitelxrooms` (
  `Room_num` int NOT NULL,
  `Vil_count` int DEFAULT NULL,
  PRIMARY KEY (`Room_num`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `zhitelxrooms`
--

LOCK TABLES `zhitelxrooms` WRITE;
/*!40000 ALTER TABLE `zhitelxrooms` DISABLE KEYS */;
INSERT INTO `zhitelxrooms` VALUES (1,4),(2,2),(3,2),(4,4),(5,4),(6,2),(7,2),(8,4),(9,4),(10,2),(11,2),(12,4),(13,4),(14,2),(15,2),(16,4),(17,4),(18,2),(19,2),(20,4),(21,4),(22,2),(23,2),(24,4),(25,4),(26,2),(27,2),(28,4),(29,4),(30,2),(31,2),(32,4),(33,4),(34,2),(35,2),(36,4),(37,4),(38,2),(39,2),(40,4),(41,4),(42,2),(43,2),(44,4),(45,4),(46,2),(47,2),(48,4),(49,4),(50,2);
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

-- Dump completed on 2022-05-10 16:58:34
