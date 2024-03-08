
type MapboxType = {
  id: string,
  properties: {
    address: string
  };
  text: string
}

const transformCoffeeData = (result: MapboxType) => {
  return {
    id: result.id,
    address: result.properties?.address || "Montreal, QC",
    name: result.text,
    imgUrl: "https://plus.unsplash.com/premium_photo-1663932464797-d4bfa4ad60ee?q=80&w=1587&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
  }
}

export const fecthCoffeeStores = async () => {

  try {
    const response = await fetch(`https://api.mapbox.com/geocoding/v5/mapbox.places/coffee.json?limit=6&proximity=ip&access_token=${process.env.MAPBOX_API}`)
    const data = await response.json();

    return data.features.map((result: MapboxType) => transformCoffeeData(result));
  }
  catch (error) {
    console.log(`Error at ${error}`);

  }
}
