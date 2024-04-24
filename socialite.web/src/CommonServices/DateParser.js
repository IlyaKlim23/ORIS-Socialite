

export function ParseDateForPost(date){
    const dateObj = new Date(date);
    const options = {
        year: "numeric",
        month: "2-digit",
        day: "2-digit",
        hours: "2-digit",
        minutes: "2-digit"
    };
    const localeDate = dateObj.toLocaleTimeString("en-GB", options);
    const parts = localeDate.split(', ')[0].split("/");
    const partsTime = localeDate.split(', ')[1].split(':')
    return `Создано ${parts[2]}.${parts[1]}.${parts[0]} в ${partsTime[0]}:${partsTime[1]}`;
}

export function ParseDateForComment(date){
    const dateObj = new Date(date);
    const options = {
        year: "numeric",
        month: "2-digit",
        day: "2-digit",
        hours: "2-digit",
        minutes: "2-digit"
    };
    const localeDate = dateObj.toLocaleTimeString("en-GB", options);
    const parts = localeDate.split(', ')[0].split("/");
    return `${parts[2]}.${parts[1]}.${parts[0]}`;
}