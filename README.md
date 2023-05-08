# [.NET] Fundamentos Entity Framework

## CRUD:
//CREATE
<pre>
var tag = new Tag { Name=".NET", Slug="dotnet"};
context.Tags.Add(tag);
context.SaveChanges();
</pre>

//UPDATE
<pre>
var tag = context.Tags.FirstOrDefault(x=>x.Id == 1);
tag.Name = ".NET";
tag.Slug = "dotnet";
context.Update(tag);
context.SaveChanges();
</pre>

//DELETE
<pre>
var tag = context.Tags.FirstOrDefault(x=>x.Id == 1);
context.Remove(tag);
context.SaveChanges();
</pre>

//READ
<pre>
var tag = context.Tags..AsNoTracking().ToList();
</pre>

<pre>
var tags = context
    .Tags
    .Where(x => x.Name.Contains(".NET"))
    .AsNoTracking()
    .ToList();
</pre>

<pre>
 var tag = context
    .Tags
    .AsNoTracking()
    .FirstOrDefault(x=>x.Id == 2);

     Console.WriteLine(tag?.Name);
</pre>

## Itens de atenção em Performace:

 <ul>
  <li>AsNoTracking</li>
  <li>Async e Await</li>
  <li>Eager Loading VS Lazy Loading</li>
  <li>Skip, Take e Paginação de dados</li>
 <li>ThenInclude</li>
 <li>Mapear Queries Puras e Views</li>
</ul>

