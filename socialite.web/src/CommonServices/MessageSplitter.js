

export default function TrimMessage(string){
    if (string.length <= 25)
        return string

    return `${string.substr(0, 25)}...`
}