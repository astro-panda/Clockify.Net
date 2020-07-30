
// Variables
let sticky = 0;

window.addEventListener("load", function() {
	// Variables
	let toggler = document.getElementsByClassName("caret");
	
	for(let i = 0; i < toggler.length; i++) {
		toggler[i].addEventListener("click", function(args) {
			args.target.parentElement.querySelector(".nested").classList.toggle("active");
			args.target.classList.toggle("caret-down");
		});
	}
	
	// Variables
	let navbar = document.getElementsByClassName("side-content")[0];
	let header = document.getElementsByClassName("page-header")[0];
	
	if(navbar) {
		sticky = Math.max(navbar.offsetTop, header.clientHeight);
		
		if(window.pageYOffset >= sticky) {
		  navbar.classList.add("sticky");
		}
		else {
		  navbar.classList.remove("sticky");
		}
	}
	
	// Variables
	const toggleButtons = document.getElementsByClassName("toggle-btn");
	
	for(let i = 0; i < toggleButtons.length; i++) {
		toggleButtons[i].addEventListener("click", function(args) {
			// Variables
			let toggleContent = args.target.parentElement.nextElementSibling;
			
			toggleButtons[i].classList.toggle("toggled");
			toggleContent.classList.toggle("toggled");
		});
	}
	
	// Variables
	const openNav = document.getElementById("open-nav");
	const nav = document.getElementsByClassName("nav-modal")[0];
	
	if(nav) {
		// Variables
		const exit = nav.getElementsByClassName("exit")[0];
		
		openNav.addEventListener("click", function(args) {
			nav.classList.toggle("toggled");
		});
		exit.addEventListener("click", function(args) {
			nav.classList.toggle("toggled");
		});
	}
	
	// Variables
	const quickLinksOriginal = document.getElementsByClassName("quick-links")[0];
	const quickLinksMenu = document.getElementsByClassName("quick-links-content")[0];
	
	if(quickLinksMenu && quickLinksOriginal) {
		if(quickLinksMenu.innerHTML == "") {
			// Variables
			let links;
			let elem;
			
			quickLinksMenu.innerHTML = quickLinksOriginal.innerHTML;
			links = quickLinksMenu.getElementsByTagName("a");
			
			for(let i = links.length - 1; i >= 0; i--) {
				links[i].addEventListener("click", function(args) {
					nav.classList.toggle("toggled");
				});
				elem = createSelectionFromMembers(i, nav);
				if(i < links.length - 1) {
					links[i].parentElement.insertBefore(elem, links[i + 1]);
				}
				else {
					links[i].parentElement.append(elem);
				}
			}
		}
	}
	
	// Variables
	const sideContent = document.getElementsByClassName("side-content")[0];
	
	if(sideContent) {
		// Variables
		const navframe = sideContent.getElementsByTagName("iframe")[0];
		const anchors = navframe.contentWindow.document.getElementsByTagName("a");
		
		for(let i = 0; i < anchors.length; i++) {
			anchors[i].addEventListener("click", function(args) {
				nav.classList.toggle("toggled");
			});
		}
	}
});

window.addEventListener("scroll", function() {
	// Variables
	let navbar = document.getElementsByClassName("side-content")[0];
	let header = document.getElementsByClassName("page-header")[0];
	
	if(!navbar || !header) { return; }

	if(sticky == -1) {
	  sticky = Math.min(navbar.offsetTop, header.clientHeight + 8);
	}

	if(window.pageYOffset >= sticky) {
	  navbar.classList.add("sticky");
	}
	else {
	  navbar.classList.remove("sticky");
	}
});

function createSelectionFromMembers(index, nav) {
	// Variables
	const table = document.getElementsByClassName("compact-member")[index];
	const namedAnchors = table.getElementsByClassName("name");
	let selections = document.createElement("select");
	let option;
	
	option = document.createElement("option");
	option.innerText = "-- Select Member --";
	selections.append(option);
	
	for(let i = 0; i < namedAnchors.length; i++) {
		if(namedAnchors[i].tagName == "A") {
			option = document.createElement("option");
			option.innerHTML = `<a href="${ namedAnchors[i].hash }">${ namedAnchors[i].innerText }</a>`;
			selections.append(option);
		}
	}
	
	selections.classList.add("select-member-list");
	selections.addEventListener("change", function(args) {
		// Variables
		let sel = args.target.selectedOptions[0];
		
		if(sel.childNodes[0].tagName == "A") {
			nav.classList.toggle("toggled");
			args.target.selectedIndex = 0;
			location.hash = sel.childNodes[0].hash;
		}
		console.dir(args.target);
	});
	
	return selections;
}
