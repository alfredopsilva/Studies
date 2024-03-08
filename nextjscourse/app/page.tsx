import Banner from "@/components/banner.client";
import Card from "@/components/card.server";
import { fecthCoffeeStores } from "@/lib/coffeeStore";

const dummyData = [
  {
    "name": "StrangeLove Coffee",
    "imgUrl": "https://images.unsplash.com/photo-1509042239860-f550ce710b93?q=80&w=1587&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
  },
  {
    "name": "Love Coffee",
    "imgUrl": "https://images.unsplash.com/photo-1533938661601-d44c02e40171?q=80&w=1470&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
  },
  {
    "name": "Quebec Coffee",
    "imgUrl": "https://images.unsplash.com/photo-1509042239860-f550ce710b93?q=80&w=1587&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
  },
  {
    "name": "Brazil Coffee",
    "imgUrl": "https://images.unsplash.com/photo-1549883498-9c1eb45b3cae?q=80&w=1470&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
  },
  {
    "name": "Mysterius Coffee",
    "imgUrl": "https://images.unsplash.com/photo-1528834453660-4b21e1ef0bf2?q=80&w=1587&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
  },
  {
    "name": "Java Coffee",
    "imgUrl": "https://images.unsplash.com/photo-1595348386360-99cf819e21f2?q=80&w=1649&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
  },
  {
    "name": "Cool Coffee",
    "imgUrl": "https://plus.unsplash.com/premium_photo-1663932464797-d4bfa4ad60ee?q=80&w=1587&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
  },
]

type coffeeStoreProps = {

  id: number,
  address: string,
  name: string,
  imgUrl: string,
}

export default async function Home() {
  const coffeeStore = await fecthCoffeeStores();
  console.log(coffeeStore);


  return (
    <main className="flex min-h-screen flex-col items-center justify-between p-24">
      <Banner buttonText={"View stores nearby"} handleOnClick={undefined} />
      <div>
        <h2 className="mt-8 pb-8 text-4xl font-bold text-white">Montreal Stores</h2>
        <div className="grid grid-cols-1 gap-4 md:grid-cols-2 md:gap-2 lg:grid-cols-3 lg:gap-6">
          {coffeeStore.map((coffeeStore: coffeeStoreProps, index: number) => {
            return (
              <Card name={coffeeStore.name} imgUrl={coffeeStore.imgUrl} href={`/coffee-store/${index}`} key={index} />
            )
          })}
        </div>
      </div>
    </main>
  );
}
