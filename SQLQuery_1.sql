use TestCategory
go

-- Insert rows into table 'CATEGORY' in schema '[dbo]'
INSERT INTO [dbo].[CATEGORY]
( -- Columns to insert data into
 [CategoryId], [CategoryName],[CategoryStatus]
)
VALUES
( -- First row: values for the columns in the list above
 '1987a883-ea3b-4774-8201-a402f91c96f7',N'Thời Sự', 1
),
( -- Second row: values for the columns in the list above
 '5dde02ca-e44b-489e-8d8d-0f6032aaae3d', N'Góc Nhìn', 1
),
( -- Second row: values for the columns in the list above
 '60f71fb3-d1d0-4fb7-9d0f-c5d013148373', N'Kinh doanh', 1
),
( -- Second row: values for the columns in the list above
 '146471fc-30da-48de-9569-3421c7f86b2b', N'PodCast', 0
)
-- Add more rows here
GO


-- Insert rows into table 'NEWS' in schema '[dbo]'
INSERT INTO [dbo].[NEWS]
( -- Columns to insert data into
 [NewsId], [CategoryId], [NewsName],[NewsStatus]
)
VALUES
( -- First row: values for the columns in the list above
 '60d4e0ad-9402-4077-839e-2d3011863d59', '1987a883-ea3b-4774-8201-a402f91c96f7', N'Chính Trị',1
),
( -- First row: values for the columns in the list above
 'd9f38ed1-5d24-4e81-9478-84c215407b5f', '1987a883-ea3b-4774-8201-a402f91c96f7', N'Dân Sinh',1
),

( -- Second row: values for the columns in the list above
 '4ca68c07-1116-444e-947c-ace1824e7d20', '5dde02ca-e44b-489e-8d8d-0f6032aaae3d', N'Covid-19',1
),
( -- Second row: values for the columns in the list above
 'e1f0ce53-3a5f-4b8d-a2e1-46fcf2022118', '5dde02ca-e44b-489e-8d8d-0f6032aaae3d', N'Y tế - Sức khỏe',1
),
( -- Second row: values for the columns in the list above
 '497ce890-2407-4989-abc6-ec6ef468c3f6', '146471fc-30da-48de-9569-3421c7f86b2b', N'VnExpress hôm nay',1
)
-- Add more rows here
GO
--  1987a883-ea3b-4774-8201-a402f91c96f7
--  5dde02ca-e44b-489e-8d8d-0f6032aaae3d
--  60f71fb3-d1d0-4fb7-9d0f-c5d013148373
--  146471fc-30da-48de-9569-3421c7f86b2b
 60d4e0ad-9402-4077-839e-2d3011863d59
 d9f38ed1-5d24-4e81-9478-84c215407b5f
 4ca68c07-1116-444e-947c-ace1824e7d20
 e1f0ce53-3a5f-4b8d-a2e1-46fcf2022118
 497ce890-2407-4989-abc6-ec6ef468c3f6
 fe52ff74-bca4-4218-9880-468aec44d340


