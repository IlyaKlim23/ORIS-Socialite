

export default function Message({isReceived, text}){
    return(
        isReceived
        ? <>
                <div className="flex gap-3 message left-0">
                    <div className="px-4 py-2 rounded-[20px] max-w-sm bg-secondery">
                        {text}
                    </div>
                </div>
            </>
        : <>
            <div className="flex gap-2 flex-row-reverse items-end message right-0">
                <div
                    className="px-4 py-2 rounded-[20px] max-w-sm bg-gradient-to-tr from-sky-500 to-blue-500 text-white shadow">
                    {text}
                </div>
            </div>
        </>
    )
}