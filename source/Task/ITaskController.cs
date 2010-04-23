
namespace Task
{

    public interface ITaskController
    {
        string GetHelpText();
        void Execute(string[] args);
    }
}
