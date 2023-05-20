let ham_menu = document.querySelector('.ham-menu');
let toggled_btn = document.querySelector('.toggle-btn');
let navbar = document.querySelector('.navbar-wrap');

ham_menu.onclick = function () {
    ham_menu.classList.toggle("toggled");
    navbar.classList.toggle("toggled");
}
toggled_btn.onclick = function () {
    ham_menu.classList.toggle("toggled");
    navbar.classList.toggle("toggled");
}