let slideIndex = 0;
let slideTimeout;
let slideshowActive = true;
let clicked = false; // Flag to track if an image was clicked

function startSlides() {
  showSlides();
}

function showSlides() {
  if (!slideshowActive) return;

  let i;
  let slides = document.getElementsByClassName("mySlides");
  let dots = document.getElementsByClassName("demo");
  for (i = 0; i < slides.length; i++) {
    slides[i].style.display = "none";
  }
  slideIndex++;
  if (slideIndex > slides.length) {
    slideIndex = 1;
  }
  for (i = 0; i < dots.length; i++) {
    dots[i].className = dots[i].className.replace(" active", "");
  }
  slides[slideIndex - 1].style.display = "block";
  dots[slideIndex - 1].className += " active";
  slideTimeout = setTimeout(showSlides, 2000); // Change image every 2 seconds
}

function pauseSlides() {
  clearTimeout(slideTimeout);
  slideshowActive = false;
}

function resumeSlides() {
  slideshowActive = true;
  if (!clicked) {
    showSlides();
  }
  clicked = false;
}

let images = document.getElementsByClassName("mySlides");
for (let i = 0; i < images.length; i++) {
  images[i].addEventListener("click", function() {
    pauseSlides();
    currentSlide(i + 1);
    clicked = true; // Mark that an image was clicked
    setTimeout(resumeSlides, 5000); // Resume after 5 seconds
  });
}

function currentSlide(n) {
  slideIndex = n;
  showSlides();
}

window.onload = function() {
  startSlides();
};
