import {filesClient} from "../../Constants/AxiosClients";


export default async function UploadFile(files){
    const data = new FormData()

    for (var x = 0; x < files.length; x++) {
        data.append("files", files[x]);
    }

    let result;
    await filesClient
        .post("", data, { headers :{
            'content-type': 'multipart/form-data'
            }})
        .then((response) =>{
            result = response
        })
        .catch((error) => {
            console.log(error);
        });

    return result
}