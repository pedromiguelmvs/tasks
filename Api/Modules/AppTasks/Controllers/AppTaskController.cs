using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("tasks")]
public class TasksController : ControllerBase
{
    private readonly List<AppTask> _products = new List<AppTask>
    {
        new AppTask { Id = 1, Name = "Item 1", Description = "Description item 1" },
        new AppTask { Id = 2, Name = "Item 2", Description = "Description item 2" }
    };

    [HttpGet]
    public ActionResult<IEnumerable<AppTask>> Get()
    {
        return Ok(_products);
    }

    [HttpGet("{id}")]
    public ActionResult<AppTask> GetById(int id)
    {
        var produto = _products.FirstOrDefault(p => p.Id == id);
        if (produto == null)
            return NotFound();
        return Ok(produto);
    }

    [HttpPost]
    public ActionResult<AppTask> Post(AppTask produto)
    {
        produto.Id = _products.Count + 1;
        _products.Add(produto);
        return CreatedAtAction(nameof(GetById), new { id = produto.Id }, produto);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, AppTask produto)
    {
        var existingProduto = _products.FirstOrDefault(p => p.Id == id);
        if (existingProduto == null)
            return NotFound();

        existingProduto.Name = produto.Name;
        existingProduto.Description = produto.Description;

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var produto = _products.FirstOrDefault(p => p.Id == id);
        if (produto == null)
            return NotFound();

        _products.Remove(produto);
        return NoContent();
    }
}
