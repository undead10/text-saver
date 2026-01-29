using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;

namespace TextSaver.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    [BindProperty]
    public string? FileName { get; set; }

    [BindProperty]
    public string? NoteContent { get; set; }

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        // Set default filename with timestamp
        FileName = $"notes_{DateTime.Now:yyyyMMdd_HHmmss}";
    }

    public IActionResult OnPost()
    {
        if (string.IsNullOrWhiteSpace(FileName))
        {
            FileName = $"notes_{DateTime.Now:yyyyMMdd_HHmmss}";
        }

        if (string.IsNullOrWhiteSpace(NoteContent))
        {
            NoteContent = "";
        }

        // Ensure the filename ends with .txt
        if (!FileName.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
        {
            FileName += ".txt";
        }

        // Convert content to bytes
        var contentBytes = Encoding.UTF8.GetBytes(NoteContent);

        // Return the file for download
        return File(contentBytes, "text/plain", FileName);
    }
}
