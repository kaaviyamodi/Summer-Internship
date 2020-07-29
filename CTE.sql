Use CHDB;
go

-- Select Everything from table
select * from Admissions;

--duplicate records in the table
-- how to delete those duplicate records?

Select *,
ROW_NUMBER() over (partition by PatientID order by PatientID) row_num
from Admissions;

with CTE_duplicatePatient as (
	Select *,
	ROW_NUMBER() over (partition by PatientID order by PatientID) row_num
	from Admissions
	)
	select * from CTE_duplicatePatient
	where row_num > 1;

-- another use for pagination

with CTE as (
	Select *,
	ROW_NUMBER() over ( order by PatientID) row_num
	from Admissions
	)
	select PatientID, AdmissionDate, DischargeDate from CTE
	where row_num > 10 and row_num <=20;

	use Sample

	select * from tblEmployee

	alter table tblEmployee add Isdup bit;

	with CTE as(
	select
	ROW_NUMBER() over ( partition by FirstName Order by FirstName) ROW_NUM, *
	from 
	tblEmployee)
	update CTE
	set IsDup = 0 where row_num = 1;

	