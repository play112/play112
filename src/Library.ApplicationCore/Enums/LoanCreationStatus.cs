using System.ComponentModel;

namespace Library.ApplicationCore.Enums;

public enum LoanCreationStatus
{
    [Description("Loan was successfully created.")]
    Success,

    [Description("Patron not found.")]
    PatronNotFound,

    [Description("Book item not found.")]
    BookItemNotFound,

    [Description("Patron has reached the maximum number of active loans.")]
    LoanLimitExceeded,

    [Description("Patron's membership has expired.")]
    MembershipExpired,

    [Description("Cannot create loan due to an error.")]
    Error
}
