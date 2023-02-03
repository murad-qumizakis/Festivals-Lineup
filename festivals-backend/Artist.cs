class Artist
{
    public int? Id { get; set; }
    public string? Name { get; set; }

    public string? Country { get; set; }

    public int? Festivalid { get; set; }

    public Festival? Festival { get; set; }

}