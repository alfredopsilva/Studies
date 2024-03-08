import React from 'react'
import Image from 'next/image'
import Link from 'next/link'
import { getPlaiceholder } from 'plaiceholder'

type CardsProps = {
  name: string,
  imgUrl: string,
  href: string
}

export default async function Card({ name, imgUrl, href }: CardsProps) {

  const buffer = await fetch(imgUrl).then(async (res) => {
    return Buffer.from(await res.arrayBuffer());
  })
  const { base64 } = await getPlaiceholder(buffer);

  return (
    <Link href={href} className='m-auto text-ellipsis whitespace-nowrap text-xl font-bold'>
      <div className='glass min-h-[200px] rouded-xl px-5 pb-5 pt-1 backdrop-blur-3xl'>
        <div className='my-3'>
          <h2 className='w-64 text-ellipsis whitespace-nowrap text-xl font-bold'>{name}</h2>
        </div>
        <div>
          <Image src={imgUrl} placeholder='blur' blurDataURL={base64} width={260} height={160} alt={`${name}'s Coffee Shop'`} className='max-h-[200px] min-h-[200px] rounded-lg shadow-lg' />
        </div>
      </div>
    </Link>
  )
}
