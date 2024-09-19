using Microsoft.AspNetCore.Razor.TagHelpers;
using EscapeRoomMVC.Models;

[HtmlTargetElement("escape-room-card")]
public class EscapeRoomCardTagHelper : TagHelper
{
    public EscapeRoom EscapeRoom { get; set; }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        var content = $@"
            <div class='escape-room-card'>
                <h3>{EscapeRoom.Name}</h3>
                <p>{EscapeRoom.Description}</p>
                <p>Время прохождения: {EscapeRoom.Duration} минут</p>
                <p>Максимум участников: {EscapeRoom.MaxPlayers}</p>
                <p>Уровень страха: {EscapeRoom.FearLevel}</p>
                <p>Уровень сложности: {EscapeRoom.DifficultyLevel}</p>
                <img src='{EscapeRoom.Logo}' alt='Логотип' />
            </div>";

        output.Content.SetHtmlContent(content);
    }
}