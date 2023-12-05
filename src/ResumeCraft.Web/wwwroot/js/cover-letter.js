
document.addEventListener("DOMContentLoaded", function () {
    const generateButton = document.getElementById("generateButton");
    generateButton.addEventListener("click", generateCoverLetter);

    function generateCoverLetter() {
        const companyName = document.getElementById("companyName").value;
        const companyAddress = document.getElementById("companyAddress").value;
        const recipientName = document.getElementById("recipientName").value;
        const content = document.getElementById("content").value;
        const userName = document.getElementById("userName").value;

        const formData = new FormData();
        formData.append("CompanyName", companyName);
        formData.append("CompanyAddress", companyAddress);
        formData.append("RecipientName", recipientName);
        formData.append("Content", content);
        formData.append("UserName", userName);

        fetch("/CoverLetter/GenerateCoverLetter", {
            method: "POST",
            body: formData
        })
            .then(response => response.text())
            .then(html => {
                const coverLetterPreview = document.getElementById("coverLetterPreview");
                coverLetterPreview.innerHTML = html;
                downloadButton.style.display = "block";
            });
    }


    const downloadButton = document.getElementById("downloadButton");
    downloadButton.addEventListener("click", downloadPdf);

    
    function downloadPdf() {
        const companyName = document.getElementById("companyName").value;
        const companyAddress = document.getElementById("companyAddress").value;
        const recipientName = document.getElementById("recipientName").value;
        const content = document.getElementById("content").value;
        const userName = document.getElementById("userName").value;

        const formData = new FormData();
        formData.append("CompanyName", companyName);
        formData.append("CompanyAddress", companyAddress);
        formData.append("RecipientName", recipientName);
        formData.append("Content", content);
        formData.append("UserName", userName);


        fetch("/CoverLetter/DownloadPdf", {
            method: "POST",
            body: formData,
            responseType: "blob"
        })
            .then(response => response.blob())
            .then(blob => {
                const url = window.URL.createObjectURL(blob);
                const a = document.createElement("a");
                a.href = url;
                a.download = "CoverLetter.pdf";
                a.click();
                window.URL.revokeObjectURL(url);
            });
    }
});
