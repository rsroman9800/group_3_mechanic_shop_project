/** ---------- Drop Tables ---------- **/

IF OBJECT_ID('dbo.invoice_table', 'U') IS NOT NULL 
  DROP TABLE dbo.invoice_table;



/** ---------- Create Tables ---------- **/


/** Invoice Table **/

USE [mechanic_db]

/****** Object:  Table [dbo].[invoice_table]    Script Date: 2024-08-06 8:01:57 AM ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[invoice_table](
	[invoice_id] [int] NOT NULL,
	[customer_id] [int] NOT NULL,
	[appointment_id] [int] NOT NULL,
	[labor_cost] [float] NOT NULL,
	[parts_cost] [float] NOT NULL,
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

