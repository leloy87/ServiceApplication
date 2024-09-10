using ServiceApplication;
using System.Collections.Generic;
using System.Linq;

public static class IssueStorage
{
    // Change the list type from List<Issue> to List<Issues>
    private static List<Issues> _issues = new List<Issues>();

    // Change the method signature from AddIssue(Issue issue) to AddIssue(Issues issue)
    public static void AddIssue(Issues issue)
    {
        _issues.Add(issue);
    }

    // Change the return type from List<Issue> to List<Issues>
    public static List<Issues> GetIssues()
    {
        return _issues.ToList();
    }
}

