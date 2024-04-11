import "./Styles/componentStyles.css"

export function AlertError(text){

    return (
        text !== "" && (typeof text === 'string' || text instanceof String)
        ? <>
            <div className="errorAlert error" role="alert">
                <span className="alertText">{text}</span>
            </div>
        </> : ""
    )
}

