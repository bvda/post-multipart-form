import axios from 'axios';
import { useState } from 'react';

const API_URL = 'https://localhost:5000/multipartformdata';

function App() {
  const [file, setFile] = useState([])
  const handleFileSubmit = async () => {
    var data = new FormData()
    data.append('file', file[0])
    data.append('id', '1337')
    const result = await axios.postForm(API_URL, data)
    console.log(result.data)
  }
  return (
    <div>
      <h1>Multipart Form Data</h1>
      <form>
        <input type={'file'} onChange={e => setFile(e.target.files)} />
        <button type='button' onClick={handleFileSubmit}>Submit</button>
      </form>
    </div>
  );
}

export default App;
