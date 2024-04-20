import {filesClient} from "../../Constants/AxiosClients";


export default async function UploadFile(file){
    const data = new FormData()
    data.append('files', file)

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