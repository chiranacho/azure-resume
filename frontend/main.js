window.addEventListener('DOMContentLoaded', (event) =>{
    getVisitCount();
})

const productionApiUrl = 'https://blz-azure-resume.azurewebsites.net/api/GetVisitorCount?code=gyHhdxY2AbYkm-dOFvHOCMU-YK_khowxqa258DZtXvaFAzFu1FWg5w==';
const localApiUrl = 'http://localhost:7071/api/GetVisitorCount';

const getVisitCount = () => {
    let count = 30;
    fetch(productionApiUrl).then(response => {
        return response.json()
    }).then(response =>{
        console.log("Website called function API.");
        count =  response.count;
        document.getElementById("counter").innerText = count;
    }).catch(function(error){
        console.log(error);
    });
    return count;
}