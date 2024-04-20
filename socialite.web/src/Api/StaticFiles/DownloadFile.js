import {filesClient} from "../../Constants/AxiosClients";

export default async function DownloadFile(fileId){

    let result;

    await filesClient
        .get("", {params : {fileId}, responseType: 'blob'})
        .then((response) => {
            result = response.data
        })
        .catch((error) => {
            console.log(error);
        });

    if (result)
        return URL.createObjectURL(result);
    else return null
}