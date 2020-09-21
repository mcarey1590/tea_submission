
USE School
GO

ALTER TABLE StudentGrade ADD CONSTRAINT CHK_GRADE CHECK (Grade BETWEEN 0.0 AND 4.0)

GO

WITH cte AS (
    SELECT 
        EnrollmentID
        ,CourseID
        ,StudentID
        ,Grade
        ,ROW_NUMBER() OVER (
            PARTITION BY 
                CourseID
                ,StudentID
                --,Grade 
            ORDER BY 
                CourseID
                ,StudentID
                --,Grade
        ) row_num
     FROM 
        StudentGrade
)
DELETE FROM cte
WHERE row_num > 1;

GO

ALTER TABLE StudentGrade ADD CONSTRAINT UQ_COURSEID_STUDENTID UNIQUE NONCLUSTERED ( [CourseID], [StudentID] )