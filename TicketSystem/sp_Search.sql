ALTER PROCEDURE sp_SearchTickets
    @Title NVARCHAR(255) = NULL,
    @Day INT = NULL,
    @Month INT = NULL,
    @Year INT = NULL,
    @CreatedBy INT = NULL,
    @DepartmentID INT = NULL,
    @AssignedTo INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        t.TicketID,
        t.Title,
        t.Description,
        t.Priority,
        t.Status,
        t.CreatedBy,
        t.DepartmentID,
        t.CategoryID,
        t.CreatedAt,
        t.UpdatedAt,
        t.DueDate,
        t.IsFeedBack,
        ta.AssignmentID,
        ta.AssignedTo,
        u.FullName,
        u.Avatar
    FROM Tickets t
    LEFT JOIN TicketAssignments ta ON t.TicketID = ta.TicketID
    LEFT JOIN Users u ON ta.AssignedTo = u.UserID
    WHERE 
        (@Title IS NULL OR t.Title COLLATE Vietnamese_CI_AI LIKE N'%' + @Title + '%')
        AND (@Day IS NULL OR DAY(t.CreatedAt) = @Day)
        AND (@Month IS NULL OR MONTH(t.CreatedAt) = @Month)
        AND (@Year IS NULL OR YEAR(t.CreatedAt) = @Year)
        AND (@CreatedBy IS NULL OR t.CreatedBy = @CreatedBy)
        AND (@DepartmentID IS NULL OR t.DepartmentID = @DepartmentID)
        AND (@AssignedTo IS NULL OR ta.AssignedTo = @AssignedTo);
END

