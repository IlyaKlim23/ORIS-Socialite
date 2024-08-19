import {ScaleLoader} from "react-spinners";

export default function Loader(loading) {

    return (
        <>
            <div className="loader-container"></div>
            <ScaleLoader
                color={'#fcfcf5'}
                loading={loading}
                size={150}
                aria-label="Loading Spinner"
                data-testid="loader"
                className="loader"
            />
        </>
    )
}
