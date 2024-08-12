

DELETE FROM invoice_table;
DELETE FROM appointment_table;
DELETE FROM vehicle_table;
DELETE FROM customer_table;

-- customerID, Name, Phone, Email
INSERT INTO customer_table VALUES (111,'Taka Turner', 1234567789, 'takaturner@email.com');
INSERT INTO customer_table VALUES (112,'Mace Howad', 1234569982, 'macehowald@email.com');
INSERT INTO customer_table VALUES (113,'Gabe Tansowny', 1234566674, 'gabetansowny@email.com');
INSERT INTO customer_table VALUES (114,'Cohan Charette', 1234568888, 'cohancharette@email.com');
INSERT INTO customer_table VALUES (115,'Roman Sorokin', 1234564477, 'romansorokin@email.com');
INSERT INTO customer_table VALUES (116,'Nasratullah Asadi', 1234563355, 'nasratullahasadi@email.com');

-- vehicleID, customerID, Make, Model, Year, VIN
INSERT INTO vehicle_table VALUES (101, 111, 'Honda', 'Civic', '1990', '1G3GS64C734119533');
INSERT INTO vehicle_table VALUES (102, 111, 'Acura', 'Integra', '1995', '1LNHM94R49G678383');
INSERT INTO vehicle_table VALUES (103, 112, 'Toyota', 'Celica', '1990', 'JTHBE262472072816');
INSERT INTO vehicle_table VALUES (104, 113, 'Kia', 'Rio', '2005', '9BWDE61JX24089008');
INSERT INTO vehicle_table VALUES (105, 114, 'Mini', 'Cooper', '2007', '4T4BF3EK1AR049206');
INSERT INTO vehicle_table VALUES (106, 116, 'BMW', '535i xDrive', '2013', 'JM1BL1SF0A1197075');
INSERT INTO vehicle_table VALUES (107, 115, 'Buick', 'Allure CXL', '2009', 'JTDJT923075051695');

-- appointmentID, customerID, vehicleID, description, labor_cost, parts_cost, date
INSERT INTO appointment_table VALUES (001, 111, 101, 'Front Brake Pad Replacement', 120.00, 100.00, '2024-08-02');
INSERT INTO appointment_table VALUES (002, 111, 102, 'Rear Brake Pad Replacement', 150.00, 100.00, '2024-09-03');
INSERT INTO appointment_table VALUES (003, 112, 103, 'Battery Replacement', 50.00, 120.00, '2024-08-06');
INSERT INTO appointment_table VALUES (004, 113, 104, 'Wheel Bearing Replacement', 350.00, 60.00, '2024-09-04');
INSERT INTO appointment_table VALUES (005, 114, 105, 'Oil Change', 40.00, 30.00, '2024-09-05');
INSERT INTO appointment_table VALUES (006, 114, 105, 'Engine Diagnostic', 100.00, 0.00, '2024-09-05');
INSERT INTO appointment_table VALUES (007, 114, 105, 'Wheel Alignment', 80.00, 0.00, '2024-09-05');
INSERT INTO appointment_table VALUES (008, 114, 105, 'Spark Plug Replacement', 60.00, 70.00, '2024-09-06');
INSERT INTO appointment_table VALUES (009, 115, 107, 'Wheel Alignment', 80.00, 0.00, '2024-09-09');
INSERT INTO appointment_table VALUES (010, 116, 106, 'Premium Oil Change', 40.00, 80.00, '2024-09-10');

-- invoiceID, customerID, appointmentID, total_cost, date_issued, date_paid
INSERT INTO invoice_table VALUES (0001, 111, 001, 220.00, '2024-08-02', '2024-08-06');
INSERT INTO invoice_table VALUES (0002, 112, 003, 170.00, '2024-08-06', '1111-11-11');
-- if the date_paid is 1111-11-11 then it hasn't been paid