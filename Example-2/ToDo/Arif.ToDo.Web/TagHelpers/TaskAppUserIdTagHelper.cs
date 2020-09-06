using System.Linq;
using Arif.ToDo.Business.Interfaces;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Arif.ToDo.Web.TagHelpers
{
    [HtmlTargetElement("GetTaskByUserId")]
    public class TaskAppUserIdTagHelper : TagHelper
    {
        private readonly ITaskService _taskService;

        public TaskAppUserIdTagHelper(ITaskService taskService)
        {
            _taskService = taskService;
        }

        public int AppUserId { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var tasks = _taskService.GetByUserId(AppUserId);
            var doneTasks = tasks.Count(I => I.Status);
            var ongoingTasks = tasks.Count(I => !I.Status);

            var htmlString = $"<strong>{doneTasks}</strong> görev tamamlandı <br>" +
                             $"<strong>{ongoingTasks}</strong> görev devam ediyor";

            output.Content.SetHtmlContent(htmlString);
        }
    }
}
