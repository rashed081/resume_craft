"use strict";
$(document).ready(function () {

	

	var map1 = L.map('kt_contact_map', {
		center: [51.5, -0.09],
		zoom: 15
	});
	map1.invalidateSize();
	L.tileLayer('https://tile.openstreetmap.org/{z}/{x}/{y}.png', {
		attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
	}).addTo(map1);

	var mapicon = L.icon({
		iconUrl: '/assets/img/mapIcon.png',
		iconSize: [25, 70],
		iconAnchor: [19, 70],
		popupAnchor: [-3, -60]
	});
	var leafletIcon = L.divIcon({
		html: `<i class="ki-solid ki-geolocation text-primary fs-3x"></span>`,
		bgPos: [10, 10],
		iconAnchor: [20, 37],
		popupAnchor: [0, -37],
		className: 'leaflet-marker'
	});
	var markerLayer = map1.getCenter();

	L.marker([23.805212783743638, 90.37009991534262], { icon: mapicon }).addTo(map1)
		.bindPopup('DevSkill<br>')
		.openPopup();



});
// Class definition
var KTContactApply = function () {
	var submitButton;
	var validator;
	var form;
	var selectedlocation;

	// Private functions

	// Init form inputs
	var initForm = function() {
		// Team assign. For more info, plase visit the official plugin site: https://select2.org/
        $(form.querySelector('[name="position"]')).on('change', function() {
            // Revalidate the field when an option is chosen
            validator.revalidateField('position');
        });		
	}

	// Handle form validation and submittion
	var handleForm = function() {
		// Stepper custom navigation

		// Init form validation rules. For more info check the FormValidation plugin's official documentation:https://formvalidation.io/
		validator = FormValidation.formValidation(
			form,
			{
				fields: {
					'name': {
						validators: {
							notEmpty: {
								message: 'Name is required'
							}
						}
					},
					'email': {
                        validators: {
							notEmpty: {
								message: 'Email address is required'
							},
                            emailAddress: {
								message: 'The value is not a valid email address'
							}
						}
					},
					'message': {
                        validators: {
							notEmpty: {
								message: 'Message is required'
							}
						}
					}		 
				},
				plugins: {
					trigger: new FormValidation.plugins.Trigger(),
					bootstrap: new FormValidation.plugins.Bootstrap5({
						rowSelector: '.fv-row',
                        eleInvalidClass: '',
                        eleValidClass: ''
					})
				}
			}
		);

		// Action buttons
		submitButton.addEventListener('click', function (e) {
			e.preventDefault();

			// Validate form before submit
			if (validator) {
				validator.validate().then(function (status) {
					console.log('validated!');

					if (status == 'Valid') {
						submitButton.setAttribute('data-kt-indicator', 'on');

						// Disable button to avoid multiple click 
						submitButton.disabled = true;

						setTimeout(function() {
							submitButton.removeAttribute('data-kt-indicator');

							// Enable button
							submitButton.disabled = false;
							
							Swal.fire({
								text: "Form has been successfully submitted!",
								icon: "success",
								buttonsStyling: false,
								confirmButtonText: "Ok, got it!",
								customClass: {
									confirmButton: "btn btn-primary"
								}
							}).then(function (result) {
								if (result.isConfirmed) {
									//form.submit();
								}
							});

							//form.submit(); // Submit form
						}, 2000);   						
					} else {
						// Scroll top

						// Show error popuo. For more info check the plugin's official documentation: https://sweetalert2.github.io/
						Swal.fire({
							text: "Sorry, looks like there are some errors detected, please try again.",
							icon: "error",
							buttonsStyling: false,
							confirmButtonText: "Ok, got it!",
							customClass: {
								confirmButton: "btn btn-primary"
							}
						}).then(function (result) {
							KTUtil.scrollTop();
						});
					}
				});
			}
		});
	}

	return {
		// Public functions
		init: function () {
			// Elements
			form = document.querySelector('#kt_contact_form');
			submitButton = document.getElementById('kt_contact_submit_button');

			initForm();
			handleForm();
			initMap('kt_contact_map');
		}
	};
}();

// On document ready
KTUtil.onDOMContentLoaded(function () {
	KTContactApply.init();
});