function title()
{
    let elem, size, text;
    elem = document.getElementsByClassName('tit');
    text = elem.innerHTML;
    size = 220;
    for (let i = 0; i < elem.length; i++)
    {
        if (elem[i].innerHTML.length > size)
        {
            text = elem[i].innerHTML.substr(0, size+20);
            elem[i].innerHTML = text + '...';
        }
        else
        {
            text = elem[i].innerHTML;
        }
        
    }
}
title();