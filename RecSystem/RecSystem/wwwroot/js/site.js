var x = document.getElementsByClassName("navbar_item_link");

for (i = 0; i < x.length; i++) {
    //console.log(x[i].innerHTML);
    if (x[i].innerHTML == document.title) {

        x[i].style.borderBottom = "5px solid #ECD4A0";
        x[i].style.paddingBottom = "5px";
    }
}