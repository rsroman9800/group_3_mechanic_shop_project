/** ---------- Drop Tables ---------- **/

IF OBJECT_ID('dbo.invoice_table', 'U') IS NOT NULL 
  DROP TABLE dbo.invoice_table;

IF OBJECT_ID('dbo.appointment_table', 'U') IS NOT NULL 
  DROP TABLE dbo.appointment_table;

IF OBJECT_ID('dbo.vehicle_table', 'U') IS NOT NULL 
  DROP TABLE dbo.vehicle_table;

IF OBJECT_ID('dbo.customer_table', 'U') IS NOT NULL 
  DROP TABLE dbo.customer_table;



/** ---------- Create Tables ---------- **/




/** Customer Table **/

USE [mechanic_db]

/****** Object:  Table [dbo].[customer_table]    Script Date: 2024-08-06 8:00:52 AM ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[customer_table](
	[customer_id] [int] NOT NULL,
	[customer_name] [nchar](70) NOT NULL,
	[customer_phone] [bigint] NOT NULL,
	[customer_email] [nchar](70) NOT NULL,
 CONSTRAINT [PK_customer_table] PRIMARY KEY CLUSTERED 
(
	[customer_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]




/** Vehicle Table **/

USE [mechanic_db]

/****** Object:  Table [dbo].[vehicle_table]    Script Date: 2024-08-06 8:01:43 AM ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[vehicle_table](
	[vehicle_id] [int] NOT NULL,
	[customer_id] [int] NOT NULL,
	[make] [nchar](25) NOT NULL,
	[model] [nchar](25) NOT NULL,
	[year] [nchar](25) NOT NULL,
	[vin] [nchar](20) NOT NULL,
 CONSTRAINT [PK_vehicle_table] PRIMARY KEY CLUSTERED 
(
	[vehicle_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[vehicle_table]  WITH CHECK ADD  CONSTRAINT [FK_vehicle_table_customer_table] FOREIGN KEY([customer_id])
REFERENCES [dbo].[customer_table] ([customer_id])

ALTER TABLE [dbo].[vehicle_table] CHECK CONSTRAINT [FK_vehicle_table_customer_table]




/** Appointment Table **/

USE [mechanic_db]

/****** Object:  Table [dbo].[appointment_table]    Script Date: 2024-08-06 8:02:19 AM ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[appointment_table](
	[appointment_id] [int] NOT NULL,
	[customer_id] [int] NOT NULL,
	[vehicle_id] [int] NOT NULL,
	[description] [nchar](100) NOT NULL,
	[labor_cost] [float] NOT NULL,
	[part_cost] [float] NOT NULL,
	[date] [date] NOT NULL,
 CONSTRAINT [PK_appointment_table] PRIMARY KEY CLUSTERED 
(
	[appointment_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[appointment_table]  WITH CHECK ADD  CONSTRAINT [FK_appointment_table_customer_table] FOREIGN KEY([customer_id])
REFERENCES [dbo].[customer_table] ([customer_id])

ALTER TABLE [dbo].[appointment_table] CHECK CONSTRAINT [FK_appointment_table_customer_table]

ALTER TABLE [dbo].[appointment_table]  WITH CHECK ADD  CONSTRAINT [FK_appointment_table_vehicle_table] FOREIGN KEY([vehicle_id])
REFERENCES [dbo].[vehicle_table] ([vehicle_id])

ALTER TABLE [dbo].[appointment_table] CHECK CONSTRAINT [FK_appointment_table_vehicle_table]




/** Invoice Table **/

USE [mechanic_db]

/****** Object:  Table [dbo].[invoice_table]    Script Date: 2024-08-06 8:01:57 AM ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[invoice_table](
	[invoice_id] [int] NOT NULL,
	[customer_id] [int] NOT NULL,
	[appointment_id] [int] NOT NULL,
	[total_cost] [float] NOT NULL,
	[date_issued] [date] NOT NULL,
	[date_paid] [date] NULL,
 CONSTRAINT [PK_invoice_table] PRIMARY KEY CLUSTERED 
(
	[invoice_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[invoice_table]  WITH CHECK ADD  CONSTRAINT [FK_invoice_table_appointment_table] FOREIGN KEY([appointment_id])
REFERENCES [dbo].[appointment_table] ([appointment_id])

ALTER TABLE [dbo].[invoice_table] CHECK CONSTRAINT [FK_invoice_table_appointment_table]

ALTER TABLE [dbo].[invoice_table]  WITH CHECK ADD  CONSTRAINT [FK_invoice_table_customer_table] FOREIGN KEY([customer_id])
REFERENCES [dbo].[customer_table] ([customer_id])

ALTER TABLE [dbo].[invoice_table] CHECK CONSTRAINT [FK_invoice_table_customer_table]

