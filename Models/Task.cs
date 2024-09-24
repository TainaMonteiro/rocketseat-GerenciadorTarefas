public class Task
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Priority { get; set; } // alta, média, baixa
    public DateTime DueDate { get; set; }
    public string Status { get; set; } // concluída, em andamento, aguardando
}